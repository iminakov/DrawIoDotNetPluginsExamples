using BaseDrawIoPlugin;
using BaseDrawIoPlugin.JsContracts;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.JsContracts
{
    public class OpenApiDocumentSchemaJsContract : BaseDrawIoJsContract<OpenApiDocumentSchemaJsContract>
    {
        public OpenApiDocumentSchemaJsContract(JsContractInteropService jsService)
            : base(jsService)
        {
        }
    }
}
