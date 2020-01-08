using BaseDrawIoPlugin;
using JsonGeoDataSchemaPlugin.JsContracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            JsContractInteropService.SetReference<JsonGeoDataSchemaDotNetContract, JsonGeoDataSchemaDotNetContract>(c => c.SetDotNetReference, DotNetContract);
            return base.OnInitializedAsync();
        }

        [Inject]
        public JsonGeoDataSchemaDotNetContract DotNetContract { get; set; }

        [Inject]
        public JsContractInteropService JsContractInteropService { get; set; }
    }
}
