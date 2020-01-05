using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.JsContracts
{
    public class OpenSwaggerSchemaDotNetContract
    {
        private readonly OpenSwaggerSchemaJsContract _jsContract;

        public OpenSwaggerSchemaDotNetContract(OpenSwaggerSchemaJsContract jsContract)
        {
            _jsContract = jsContract;
        }

        [JSInvokable("HandleMenuActionOpenSwaggerSchema")]
        public Task HandleMenuActionOpenSwaggerSchema()
        {
            _jsContract.OpenFile();
            return Task.CompletedTask;
        }

        [JSInvokable("OnLoadFile")]
        public Task OnLoadFile(string content)
        {
            _jsContract.Log(content);
            return Task.CompletedTask;
        }

        public void SetDotNetReference() {}
    }
}
