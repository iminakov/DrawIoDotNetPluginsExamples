using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using OpenSwaggerSchemaPlugin.JsContracts;
using OpenSwaggerSchemaPlugin.Services;

namespace OpenSwaggerSchemaPlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OpenSwaggerSchemaDotNetContract>();
            services.AddSingleton<JsContractInteropService>();
            services.AddSingleton<IEditorUiService>(x => new EditorUiService(x.GetService<JsContractInteropService>()));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("OpenSwaggerSchemaPluginApp");
        }
    }
}
