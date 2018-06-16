using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Core.Queries;
using StackExchange.Redis;
using static MessageBoard.Voting.Redis.Mappings;

namespace MessageBoard.Voting.Redis.Handlers
{
    public class VoteCountBatchHandler : IRequestHandler<VoteCountBatchQuery, IEnumerable<Vote>>
    {
        private readonly IDatabase _db;

        public VoteCountBatchHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vote>> Handle(VoteCountBatchQuery request, CancellationToken cancellationToken)
        {
            var batch = _db.CreateBatch();
            var hashTasks = request.SubjectIds
                .Select(subjectId => batch.HashGetAllAsync(MapKey(subjectId)))
                .ToArray();

            batch.Execute();

            var results = await Task.WhenAll(hashTasks);
            return results.SelectMany((entries, index) => ToModel(request.SubjectIds[index], entries));
        }
    }
}
