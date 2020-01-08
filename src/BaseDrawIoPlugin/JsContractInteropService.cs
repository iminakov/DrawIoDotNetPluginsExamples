using BaseDrawIoPlugin.Extensions;
using Microsoft.JSInterop;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseDrawIoPlugin
{
    public class JsContractInteropService : IJsContractInteropService
    {
        private readonly IJSRuntime _jSRuntime;

        public JsContractInteropService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task SetReferenceInJsContext(IDotNetInteropContract service)
        {
            var reference = DotNetObjectReference.Create(service);
            await RunJsAction(service.GetType(), nameof(IDotNetInteropContract.SetDotNetReference), reference);
        }

        public async Task RunJsAction<T>(Expression<Func<T, Action>> expression, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{ExpressionExtensions.GetMethodName(expression).ToJs()}", args);
        }

        public async Task RunJsAction<T>(string methodName, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{typeof(T).Name}.{methodName.ToJs()}", args);
        }

        public async Task RunJsAction(Type jsContractType, string methodName, params object[] args)
        {
            await _jSRuntime.InvokeVoidAsync($"{jsContractType.Name}.{methodName.ToJs()}", args);
        }
    }
}
