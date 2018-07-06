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
            var results = await (request.OptionNames == null || !request.OptionNames.Any()
                ? GetAllOptions(request.SubjectIds)
                : GetOptions(request.SubjectIds, request.OptionNames));

            return results.SelectMany((entries, index) => ToModel(request.SubjectIds[index], entries));
        }

        private async Task<IEnumerable<HashEntry[]>> GetAllOptions(string[] subjectIds)
        {
            var batch = _db.CreateBatch();
            var hashTasks = subjectIds
                .Select(subjectId => batch.HashGetAllAsync(MapKey(subjectId)))
                .ToArray();

            batch.Execute();

            return await Task.WhenAll(hashTasks);
        }

        private async Task<IEnumerable<HashEntry[]>> GetOptions(string[] subjectIds, string[] options)
        {
            var batch = _db.CreateBatch();
            var redisOptions = options
                .Select(option => (RedisValue)option)
                .ToArray();

            var hashTasks = subjectIds
                .Select(subjectId => batch.HashGetAsync(MapKey(subjectId), redisOptions))
                .ToArray();

            batch.Execute();

            var results = await Task.WhenAll(hashTasks);
            return results.Select(item => item
                .Select((count, index) => new HashEntry(redisOptions[index], count))
                .ToArray()
                );
        }
    }
}
