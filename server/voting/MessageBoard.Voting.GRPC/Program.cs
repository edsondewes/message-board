using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MessageBoard.Voting.GRPC
{
    class Program
    {
        static ManualResetEvent ShutdownEvent = new ManualResetEvent(false);

        static IConfigurationRoot Configuration;
        static IServiceProvider ServiceProvider;

        public static async Task Main()
        {
            Configure();

            var serverConfig = GetServerConfig();
            var server = new Server
            {
                Services = { VoteService.BindService(ServiceProvider.GetRequiredService<VoteServiceImpl>()) },
                Ports = { new ServerPort(serverConfig.host, serverConfig.port, ServerCredentials.Insecure) }
            };

            server.Start();
            Console.WriteLine($"GRPC server running: {serverConfig.host}:{serverConfig.port}");

            ShutdownEvent.WaitOne();
            Console.WriteLine("Server is shutting down");
            await server.ShutdownAsync();
        }

        private static void Configure()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            ServiceProvider = new ServiceCollection()
                .AddRedis(Configuration["Redis"])
                .AddNats(Configuration["Nats"])
                .AddMediatR()
                .AddSingleton<VoteServiceImpl>()
                .BuildServiceProvider();
        }

        private static (string host, int port) GetServerConfig()
        {
            var section = Configuration.GetSection("GRPC");
            return (
                host: section["host"],
                port: Convert.ToInt32(section["port"])
                );
        }
    }
}