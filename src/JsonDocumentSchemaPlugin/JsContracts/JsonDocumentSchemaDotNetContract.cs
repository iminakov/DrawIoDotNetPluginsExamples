using BaseDrawIoPlugin;
using BaseDrawIoPlugin.XmlLayout;
using JsonGeoDataSchemaPlugin.Services;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin.JsContracts
{
    public class JsonGeoDataSchemaDotNetContract : IDotNetInteropContract
    {
        private readonly JsonGeoDataSchemaJsContract _jsContract;

        public JsonGeoDataSchemaDotNetContract(JsonGeoDataSchemaJsContract jsContract)
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
                var builder = new JsonGeoDataDiagramBuilder(content, new DiagramXmlBuilder());
                await _jsContract.LoadXml(builder.BuildDiagram());
            }
            catch(Exception ex)
            {
                await _jsContract.ShowError(ex.Message);
            }
        }
    }
}
