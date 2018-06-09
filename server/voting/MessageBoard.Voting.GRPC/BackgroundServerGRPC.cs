using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Voting.GRPC
{
    public class BackgroundServerGRPC : BackgroundService
    {
        private readonly Server _server;

        public BackgroundServerGRPC(VoteServiceImpl voteServiceImpl)
        {
            _server = new Server
            {
                Services = { VoteService.BindService(voteServiceImpl) },
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