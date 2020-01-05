using OpenSwaggerSchemaPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.JsContracts
{
    public class OpenSwaggerSchemaDotNetContract
    {
        private readonly IEditorUiService _editorUiService;

        public OpenSwaggerSchemaDotNetContract(IEditorUiService EditorUiService)
        {
            _editorUiService = EditorUiService;
        }

        public Task HandleMenuActionOpenSwaggerSchema()
        {
            _editorUiService.OpenAndReadFile();
            return Task.CompletedTask;
        }

        public Task OnLoadFile(string content)
        {
            _editorUiService.LogContent(content).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public void SetDotNetReference() {}
    }
}
