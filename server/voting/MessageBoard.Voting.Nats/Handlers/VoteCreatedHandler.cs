using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core.Events;

namespace MessageBoard.Voting.Nats.Handlers
{
    public class VoteCreatedHandler : INotificationHandler<VoteCreated>
    {
        private readonly IEventBus _eventBus;

        public VoteCreatedHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(VoteCreated notification, CancellationToken cancellationToken)
        {
            return _eventBus.Publish(notification);
        }
    }
}
