using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Voting.Core.Events
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
            _eventBus.Publish(notification);
            return Task.CompletedTask;
        }
    }
}
