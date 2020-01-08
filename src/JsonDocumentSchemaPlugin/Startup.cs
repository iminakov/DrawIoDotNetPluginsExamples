using BaseDrawIoPlugin;
using JsonGeoDataSchemaPlugin.JsContracts;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace JsonGeoDataSchemaPlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JsonGeoDataSchemaDotNetContract>();
            services.AddSingleton<JsContractInteropService>();
            services.AddSingleton<JsonGeoDataSchemaJsContract>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("JsonGeoDataSchemaPluginApp");
        }
    }
}
