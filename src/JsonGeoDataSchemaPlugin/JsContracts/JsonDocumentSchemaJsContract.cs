using BaseDrawIoPlugin;
using BaseDrawIoPlugin.JsContracts;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin.JsContracts
{
    public class JsonGeoDataSchemaJsContract : BaseDrawIoJsContract<JsonGeoDataSchemaJsContract>, IJsInteropContract
    {
        public JsonGeoDataSchemaJsContract(IJsContractInteropService jsService)
            : base(jsService)
        {
        }
    }
}
