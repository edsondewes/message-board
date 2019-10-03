using System;
using System.Linq;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Messaging.GRPC
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<GrpcServerConfig>(hostContext.Configuration.GetSection("GRPC").Get<GrpcServerConfig>());
                    services.AddRedis(hostContext.Configuration.GetValue<string>("Redis"));
                    services.AddMediatR(
                        AppDomain.CurrentDomain.GetAssemblies()
                        .Where(a => a.FullName != null && a.FullName.StartsWith("MessageBoard"))
                        .ToArray()
                        );
                    services.AddSingleton<MessageServiceImpl>();
                    services.AddHostedService<GrpcServer>();
                });
    }
}