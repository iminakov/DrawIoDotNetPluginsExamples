using OpenApiDocumentSchemaPlugin.Services;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.JsContracts
{
    public class OpenApiDocumentSchemaJsContract
    {
        private readonly JsContractInteropService _jsService;

        public OpenApiDocumentSchemaJsContract(JsContractInteropService jsService)
        {
            _jsService = jsService;
        }

        public async Task Log(string content)
        {
            await _jsService.RunAction<OpenApiDocumentSchemaJsContract>(nameof(Log), content);
        }

        public async Task ShowError(string message)
        {
            await _jsService.RunAction<OpenApiDocumentSchemaJsContract>(nameof(ShowError), message);
        }

        public async Task LoadXml(string xmlContent)
        {
            await _jsService.RunAction<OpenApiDocumentSchemaJsContract>(nameof(LoadXml), xmlContent);
        }

        public async Task OpenFile()
        {
            await _jsService.RunAction<OpenApiDocumentSchemaJsContract>(nameof(OpenFile));
        }
    }
}
