using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MessageBoard.Ranking.GRPC
{
    public class GrpcServer : IHostedService
    {
        private readonly ILogger<GrpcServer> _logger;
        private readonly Server _server;

        public GrpcServer(GrpcServerConfig config, ILogger<GrpcServer> logger, RankingServiceImpl serviceImpl)
        {
            _logger = logger;
            _server = new Server
            {
                Services = { RankingService.BindService(serviceImpl) },
                Ports = { new ServerPort(config.Host, config.Port, ServerCredentials.Insecure) }
            };
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _server.Start();
            _logger.LogInformation("GRPC Server is running");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GRPC Server is shutting down");
            return _server.ShutdownAsync();
        }
    }
}