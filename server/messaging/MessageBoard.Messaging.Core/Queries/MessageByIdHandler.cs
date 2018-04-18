using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class MessageByIdHandler : IRequestHandler<MessageByIdQuery, Message>
    {
        private IMessageRepository _repository;

        public MessageByIdHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public Task<Message> Handle(MessageByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
