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

        public JsContractInteropService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
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

        public async Task RunAction<T>(string methodName, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{methodName.ToJs()}", args);
        }

        internal string GetMethodName<T>(Expression<Func<T, Action>> expression)
        {
            var unaryExpression = (UnaryExpression)expression.Body;
            var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
            return ((MemberInfo)((ConstantExpression)methodCallExpression.Object).Value).Name;
        }
    }
}
