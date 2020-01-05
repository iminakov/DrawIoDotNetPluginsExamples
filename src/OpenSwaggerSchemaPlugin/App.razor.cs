using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OpenApiDocumentSchemaPlugin.JsContracts;
using OpenApiDocumentSchemaPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            JsContractInteropService.SetReference<OpenApiDocumentSchemaDotNetContract, OpenApiDocumentSchemaDotNetContract>(c => c.SetDotNetReference, DotNetContract);
            return base.OnInitializedAsync();
        }

        [Inject]
        public OpenApiDocumentSchemaDotNetContract DotNetContract { get; set; }

        [Inject]
        public JsContractInteropService JsContractInteropService { get; set; }
    }
}
