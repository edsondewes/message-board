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
    public class MessageByIdBatchHandler : IRequestHandler<MessageByIdBatchQuery, IEnumerable<Message>>
    {
        private readonly IDatabase _db;

        public MessageByIdBatchHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Message>> Handle(MessageByIdBatchQuery request, CancellationToken cancellationToken)
        {
            var batch = _db.CreateBatch();
            var hashTasks = request.Ids
                .Select(id => batch.HashGetAllAsync(MapKey(id)))
                .ToArray();

            batch.Execute();

            var results = await Task.WhenAll(hashTasks);
            return results.Select((entries, index) => ToModel(request.Ids[index], entries));
        }
    }
}
