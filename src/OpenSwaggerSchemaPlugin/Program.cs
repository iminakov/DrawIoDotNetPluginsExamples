using Microsoft.AspNetCore.Blazor.Hosting;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OpenSwaggerSchemaPluginTest")]

namespace OpenSwaggerSchemaPlugin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
