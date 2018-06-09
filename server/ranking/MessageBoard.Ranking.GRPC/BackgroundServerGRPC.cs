using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Ranking.GRPC
{
    public class BackgroundServerGRPC : BackgroundService
    {
        private readonly Server _server;

        public BackgroundServerGRPC(RankingServiceImpl rankingServiceImpl)
        {
            _server = new Server
            {
                Services = { RankingService.BindService(rankingServiceImpl) },
                Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
            };
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _server.Start();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return _server.ShutdownAsync();
        }
    }
}