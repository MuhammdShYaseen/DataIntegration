using DataIntegration.Infrastructure.DependencyInjection;
using DataIntegration.Services.Orchestration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataIntegration
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            var services = new ServiceCollection();
            services.AddIntegrationServices(configuration);

            var provider = services.BuildServiceProvider();
            var orchestrator = provider.GetRequiredService<IDataSyncOrchestrator>();

            await orchestrator.RunAsync();
            Console.WriteLine("Sync completed successfully");
        }
    }
}
