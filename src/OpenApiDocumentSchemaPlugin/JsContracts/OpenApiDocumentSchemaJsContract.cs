using BaseDrawIoPlugin;
using BaseDrawIoPlugin.JsContracts;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.JsContracts
{
    public class OpenApiDocumentSchemaJsContract : BaseDrawIoJsContract<OpenApiDocumentSchemaJsContract>, IJsInteropContract
    {
        public OpenApiDocumentSchemaJsContract(IJsContractInteropService jsService)
            : base(jsService)
        {
        }
    }
}
