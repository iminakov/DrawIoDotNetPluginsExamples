using Microsoft.JSInterop;
using NSwag;
using OpenApiDocumentSchemaPlugin.Model;
using System;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.JsContracts
{
    public class OpenApiDocumentSchemaDotNetContract
    {
        private readonly OpenApiDocumentSchemaJsContract _jsContract;

        public OpenApiDocumentSchemaDotNetContract(OpenApiDocumentSchemaJsContract jsContract)
        {
            _jsContract = jsContract;
        }

        [JSInvokable("OnMenuClick")]
        public Task OnMenuClick()
        {
            _jsContract.OpenFile();
            return Task.CompletedTask;
        }

        [JSInvokable("OnLoadFile")]
        public async Task OnLoadFile(string content)
        {
            try
            {
                var openApiDocument = await OpenApiDocument.FromJsonAsync(content);
                var openApiDiagramBuilder = new OpenApiDiagramBuilder(openApiDocument, new DiagramXmlBuilder());
                _jsContract.LoadXml(openApiDiagramBuilder.BuildDiagram());
            }
            catch(Exception ex)
            {
                _jsContract.ShowError(ex.Message);
            }
        }

        public void SetDotNetReference() {}
    }
}
