using BaseDrawIoPlugin.XmlLayout;
using JsonGeoDataSchemaPlugin.Services;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin.JsContracts
{
    public class JsonGeoDataSchemaDotNetContract
    {
        private readonly JsonGeoDataSchemaJsContract _jsContract;

        public JsonGeoDataSchemaDotNetContract(JsonGeoDataSchemaJsContract jsContract)
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
                var builder = new JsonGeoDataDiagramBuilder(content, new DiagramXmlBuilder());
                _jsContract.LoadXml(builder.BuildDiagram());
            }
            catch(Exception ex)
            {
                _jsContract.ShowError(ex.Message);
            }
        }

        public void SetDotNetReference() {}
    }
}
