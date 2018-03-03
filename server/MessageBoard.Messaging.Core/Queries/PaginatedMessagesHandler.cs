using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class PaginatedMessagesHandler : IRequestHandler<PaginatedMessagesQuery, IEnumerable<Message>>
    {
        private IMessageRepository _repository;

        public PaginatedMessagesHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Message>> Handle(PaginatedMessagesQuery request, CancellationToken cancellationToken)
        {
            return _repository.List(request.From);
        }
    }
}
