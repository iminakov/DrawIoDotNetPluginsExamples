using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OpenSwaggerSchemaPlugin.JsContracts;
using OpenSwaggerSchemaPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            JsContractInteropService.SetReference<OpenSwaggerSchemaDotNetContract, OpenSwaggerSchemaDotNetContract>(c => c.SetDotNetReference, DotNetContract);
            return base.OnInitializedAsync();
        }

        [Inject]
        public OpenSwaggerSchemaDotNetContract DotNetContract { get; set; }

        [Inject]
        public JsContractInteropService JsContractInteropService { get; set; }
    }
}
