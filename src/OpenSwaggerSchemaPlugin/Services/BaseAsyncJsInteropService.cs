using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Services
{
    public abstract class BaseAsyncJsInteropService
    {
        protected readonly IJSRuntime _jSRuntime;

        public BaseAsyncJsInteropService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        private DotNetObjectReference<BaseAsyncJsInteropService> _callBackService;

        public static object CreateDotNetObjectRefSyncObj = new object();
        public readonly ConcurrentDictionary<string, Action<string>> _asyncResultsCallback = new ConcurrentDictionary<string, Action<string>>();

        // Hack to fix https://github.com/aspnet/AspNetCore/issues/11159    
        private DotNetObjectReference<BaseAsyncJsInteropService> GetDotNetObjectRef()
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

        protected async Task RunAsyncAction<T>(Expression<Func<T, Action>> expression, Action<string> asyncResultCallBack)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{GetMethodName(expression)}", GetDotNetObjectRef(), nameof(GetAsyncResultCallback), PushRequestGuid(asyncResultCallBack));
        }

        protected async Task RunAction<T>(Expression<Func<T, Action>> expression, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{GetMethodName(expression)}", args);
        }

        internal string GetMethodName<T>(Expression<Func<T, Action>> expression)
        {
            var unaryExpression = (UnaryExpression)expression.Body;
            var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
            return ((MemberInfo)((ConstantExpression)methodCallExpression.Object).Value).Name;
        }

        protected async Task RunAction<T>(string jsObject, string jsObjectMethod, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{jsObject}.{jsObjectMethod}", args);
        }

        protected async Task RunAsyncAction(string jsObject, string jsObjectMethod, Action<string> asyncResultCallBack)
        {
            await _jSRuntime.InvokeVoidAsync($"{jsObject}.{jsObjectMethod}", GetDotNetObjectRef(), nameof(GetAsyncResultCallback), PushRequestGuid(asyncResultCallBack));
        }

        protected async Task RunAction(string jsObject, string jsObjectMethod, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{jsObject}.{jsObjectMethod}", args);
        }

        [JSInvokable]
        public void GetAsyncResultCallback(string asyncRequestGuid, string data)
        {
            TakeRequestGuid(asyncRequestGuid)?.Invoke(data);
        }

        protected string PushRequestGuid(Action<string> asyncResultCallBack)
        {
            var guid = Guid.NewGuid().ToString();

            _asyncResultsCallback.TryAdd(guid, asyncResultCallBack);

            return guid;
        }

        protected Action<string> TakeRequestGuid(string asyncRequestGuid)
        {
            if (_asyncResultsCallback.TryRemove(asyncRequestGuid, out var action))
            {
                return action;
            }

            return null;
        }
    }
}
