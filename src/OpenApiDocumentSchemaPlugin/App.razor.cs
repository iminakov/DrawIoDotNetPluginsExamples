using BaseDrawIoPlugin;
using Microsoft.AspNetCore.Components;
using OpenApiDocumentSchemaPlugin.JsContracts;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            _ = JsContractInteropService.SetReferenceInJsContext(DotNetContract);
            return base.OnInitializedAsync();
        }

        [Inject]
        public OpenApiDocumentSchemaDotNetContract DotNetContract { get; set; }

        [Inject]
        public IJsContractInteropService JsContractInteropService { get; set; }
    }
}
