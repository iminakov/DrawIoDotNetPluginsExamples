using OpenSwaggerSchemaPlugin.JsContracts;
using System;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Services
{
    public class EditorUiService : IEditorUiService
    {
        private readonly JsContractInteropService _jsService;

        public EditorUiService(JsContractInteropService jsService)
        {
            _jsService = jsService;
        }

        public async Task LogContent(string content)
        {
            await _jsService.RunAction<OpenSwaggerSchemaJsContract>(c => c.Log, content);
        }

        public async Task OpenAndReadFile()
        {
            await _jsService.RunAction<OpenSwaggerSchemaJsContract>(c => c.OpenFile);
        }
    }
}
