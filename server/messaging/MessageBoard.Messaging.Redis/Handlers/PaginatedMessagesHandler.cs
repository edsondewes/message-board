using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Queries;
using StackExchange.Redis;
using static MessageBoard.Messaging.Redis.Mappings;

namespace MessageBoard.Messaging.Redis.Handlers
{
    public class PaginatedMessagesHandler : IRequestHandler<PaginatedMessagesQuery, IEnumerable<Message>>
    {
        private readonly IDatabase _db;
        private readonly IMediator _mediator;

        public PaginatedMessagesHandler(IDatabase db, IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Message>> Handle(PaginatedMessagesQuery request, CancellationToken cancellationToken)
        {
            var ids = await _db.SortedSetRangeByScoreAsync(MessageListKey,
                stop: request.From ?? double.PositiveInfinity,
                exclude: request.From.HasValue ? Exclude.Stop : Exclude.None,
                order: Order.Descending,
                take: request.PageSize);

            var list = await Task.WhenAll(
                    ids.Select(id => _mediator.Send(new MessageByIdQuery((long)id)))
                );

            return list;
        }
    }
}
