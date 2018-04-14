using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Ranking.Core.Commands;
using MessageBoard.Ranking.Nats.Interop;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
using Newtonsoft.Json;

namespace MessageBoard.Ranking.Nats
{
    public class SubscriptionsServiceNats : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IServiceScopeFactory _scopeFactory;
        private IAsyncSubscription _subscription;

        public SubscriptionsServiceNats(IServiceScopeFactory scopeFactory, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var options = ConnectionFactory.GetDefaultOptions();
            options.Url = url;

            _connection = new ConnectionFactory().CreateConnection(options);
            _scopeFactory = scopeFactory;
        }

        public override void Dispose()
        {
            _subscription?.Dispose();
            _connection.Dispose();
            base.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscription = _connection.SubscribeAsync(nameof(VoteCreated));
            _subscription.MessageHandler += async (sender, args) =>
            {
                var obj = JsonConvert.DeserializeObject<VoteCreated>(Encoding.UTF8.GetString(args.Message.Data));
                using (var scope = _scopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(new AddVoteCommand(obj.SubjectId, obj.OptionName));
                }
            };

            _subscription.Start();

            return Task.CompletedTask;
        }
    }
}