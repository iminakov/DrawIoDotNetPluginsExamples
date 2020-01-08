using BaseDrawIoPlugin;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using OpenApiDocumentSchemaPlugin.JsContracts;

namespace OpenApiDocumentSchemaPlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OpenApiDocumentSchemaDotNetContract>();
            services.AddSingleton<IJsContractInteropService>(c => new JsContractInteropService(c.GetService<IJSRuntime>()));
            services.AddSingleton<OpenApiDocumentSchemaJsContract>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("OpenApiDocumentSchemaPluginApp");
        }
    }
}
