using BaseDrawIoPlugin;
using JsonGeoDataSchemaPlugin.JsContracts;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace JsonGeoDataSchemaPlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JsonGeoDataSchemaDotNetContract>();
            services.AddSingleton<IJsContractInteropService>(c => new JsContractInteropService(c.GetService<IJSRuntime>()));
            services.AddSingleton<JsonGeoDataSchemaJsContract>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("JsonGeoDataSchemaPluginApp");
        }
    }
}
