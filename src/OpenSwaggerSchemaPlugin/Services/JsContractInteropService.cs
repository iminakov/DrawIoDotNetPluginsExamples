using Microsoft.JSInterop;
using OpenSwaggerSchemaPlugin.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Services
{
    public class JsContractInteropService
    {
        private readonly IJSRuntime _jSRuntime;

        private DotNetObjectReference<JsContractInteropService> _callBackService;

        private static object CreateDotNetObjectRefSyncObj = new object();

        private readonly ConcurrentDictionary<string, Action<string>> _asyncResultsCallback = new ConcurrentDictionary<string, Action<string>>();

        public JsContractInteropService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        // Hack to fix https://github.com/aspnet/AspNetCore/issues/11159    
        private DotNetObjectReference<JsContractInteropService> GetDotNetObjectRef()
        {
            if (_callBackService == null)
            {
                lock (CreateDotNetObjectRefSyncObj)
                {
                    if (_callBackService == null)
                    {
                        _callBackService = DotNetObjectReference.Create(this);
                    }
                }
            }

            return _callBackService;
        }

        public async Task<DotNetObjectReference<TReference>> SetReference<TJsContract, TReference>(Expression<Func<TJsContract, Action>> expression, TReference service)
        where TReference : class
        {
            var reference = DotNetObjectReference.Create(service);
            await RunAction(expression, reference);
            return reference;
        }

        public async Task RunAction<T>(Expression<Func<T, Action>> expression, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{GetMethodName(expression).ToJs()}", args);
        }

        internal string GetMethodName<T>(Expression<Func<T, Action>> expression)
        {
            var unaryExpression = (UnaryExpression)expression.Body;
            var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
            return ((MemberInfo)((ConstantExpression)methodCallExpression.Object).Value).Name;
        }

        public async Task RunAsyncAction<T>(Expression<Func<T, Action>> expression, Action<string> asyncResultCallBack)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{GetMethodName(expression).ToJs()}", GetDotNetObjectRef(), nameof(GetAsyncResultCallback), PushRequestGuid(asyncResultCallBack));
        }

        [JSInvokable]
        public void GetAsyncResultCallback(string asyncRequestGuid, string data)
        {
            TakeRequestGuid(asyncRequestGuid)?.Invoke(data);
        }

        private string PushRequestGuid(Action<string> asyncResultCallBack)
        {
            var guid = Guid.NewGuid().ToString();

            _asyncResultsCallback.TryAdd(guid, asyncResultCallBack);

            return guid;
        }

        private Action<string> TakeRequestGuid(string asyncRequestGuid)
        {
            if (_asyncResultsCallback.TryRemove(asyncRequestGuid, out var action))
            {
                return action;
            }

            return null;
        }
    }
}
