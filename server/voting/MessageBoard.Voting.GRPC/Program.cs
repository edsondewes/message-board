using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MessageBoard.Voting.GRPC
{
    class Program
    {
        public static async Task Main()
        {
            var builder = CreateHostBuilder();
            await builder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder() => new HostBuilder()
            .ConfigureHostConfiguration(builder =>
            {
                builder.AddEnvironmentVariables();
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<GrpcServerConfig>(hostContext.Configuration.GetSection("GRPC").Get<GrpcServerConfig>());
                services.AddRedis(hostContext.Configuration.GetValue<string>("Redis"));
                services.AddNats(hostContext.Configuration.GetValue<string>("Nats"));
                services.AddMediatR();
                services.AddSingleton<VoteServiceImpl>();
                services.AddHostedService<GrpcServer>();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
    }
}