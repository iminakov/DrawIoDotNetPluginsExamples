using BaseDrawIoPlugin.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseDrawIoPlugin
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
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{ExpressionExtensions.GetMethodName(expression).ToJs()}", args);
        }

        public async Task RunAction<T>(string methodName, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{methodName.ToJs()}", args);
        }
    }
}
