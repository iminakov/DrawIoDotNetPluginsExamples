using BaseDrawIoPlugin;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using OpenApiDocumentSchemaPlugin.JsContracts;
using OpenApiDocumentSchemaPlugin.Services;

namespace OpenApiDocumentSchemaPlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OpenApiDocumentSchemaDotNetContract>();
            services.AddSingleton<JsContractInteropService>();
            services.AddSingleton<OpenApiDocumentSchemaJsContract>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("OpenApiDocumentSchemaPluginApp");
        }
    }
}
