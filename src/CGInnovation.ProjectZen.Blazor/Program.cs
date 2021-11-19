using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;


namespace CGInnovation.ProjectZen.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTM3MDQ5QDMxMzkyZTMzMmUzMGRwSnVQcnFwVENNWWdGU2JralJ2aXlHM1FMcmFMVzAvWlZsdUl2UG9HaHM9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = builder.AddApplication<ProjectZenBlazorModule>(options =>
            {
                options.UseAutofac();
            });

            builder.Services.AddSyncfusionBlazor();
            
            var host = builder.Build();

            await application.InitializeAsync(host.Services);

            await host.RunAsync();
        }
    }
}
