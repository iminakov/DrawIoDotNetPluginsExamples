using OpenSwaggerSchemaPlugin.Services;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.JsContracts
{
    public class OpenSwaggerSchemaJsContract
    {
        private readonly JsContractInteropService _jsService;

        public OpenSwaggerSchemaJsContract(JsContractInteropService jsService)
        {
            _jsService = jsService;
        }

        public async Task Log(string content)
        {
            await _jsService.RunAction<OpenSwaggerSchemaJsContract>(nameof(Log), content);
        }

        public async Task LoadXml(string xmlContent)
        {
            await _jsService.RunAction<OpenSwaggerSchemaJsContract>(nameof(LoadXml), xmlContent);
        }

        public async Task OpenFile()
        {
            await _jsService.RunAction<OpenSwaggerSchemaJsContract>(nameof(OpenFile));
        }
    }
}
