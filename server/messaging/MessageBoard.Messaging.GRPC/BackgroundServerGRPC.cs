using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Messaging.GRPC
{
    public class BackgroundServerGRPC : IHostedService
    {
        private readonly Server _server;

        public BackgroundServerGRPC(MessageServiceImpl messageServiceImpl)
        {
            _server = new Server
            {
                Services = { MessageService.BindService(messageServiceImpl) },
                Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
            };
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _server.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _server.ShutdownAsync();
        }
    }
}