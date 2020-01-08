using BaseDrawIoPlugin;
using BaseDrawIoPlugin.JsContracts;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin.JsContracts
{
    public class JsonGeoDataSchemaJsContract : BaseDrawIoJsContract<JsonGeoDataSchemaJsContract>
    {
        public JsonGeoDataSchemaJsContract(JsContractInteropService jsService)
            : base(jsService)
        {
        }
    }
}
