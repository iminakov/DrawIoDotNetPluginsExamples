using BaseDrawIoPlugin;
using BaseDrawIoPlugin.XmlLayout;
using Microsoft.JSInterop;
using NSwag;
using OpenApiDocumentSchemaPlugin.Services;
using System;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.JsContracts
{
    public class OpenApiDocumentSchemaDotNetContract : IDotNetInteropContract
    {
        private readonly OpenApiDocumentSchemaJsContract _jsContract;

        public OpenApiDocumentSchemaDotNetContract(OpenApiDocumentSchemaJsContract jsContract)
        {
            _jsContract = jsContract;
        }

        [JSInvokable("OnMenuClick")]
        public async Task OnMenuClick()
        {
            await _jsContract.OpenFile().ConfigureAwait(false);
        }

        [JSInvokable("OnLoadFile")]
        public async Task OnLoadFile(string content)
        {
            try
            {
                var openApiDocument = await OpenApiDocument.FromJsonAsync(content);
                var openApiDiagramBuilder = new OpenApiDiagramBuilder(openApiDocument, new DiagramXmlBuilder());
                await _jsContract.LoadXml(openApiDiagramBuilder.BuildDiagram());
            }
            catch(Exception ex)
            {
                await _jsContract.ShowError(ex.Message);
            }
        }

        public void SetDotNetReference() {}
    }
}
