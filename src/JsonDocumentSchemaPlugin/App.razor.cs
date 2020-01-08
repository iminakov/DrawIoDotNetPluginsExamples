using BaseDrawIoPlugin;
using JsonGeoDataSchemaPlugin.JsContracts;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            _ = JsContractInteropService.SetReferenceInJsContext(DotNetContract);
            return base.OnInitializedAsync();
        }

        [Inject]
        public JsonGeoDataSchemaDotNetContract DotNetContract { get; set; }

        [Inject]
        public IJsContractInteropService JsContractInteropService { get; set; }
    }
}
