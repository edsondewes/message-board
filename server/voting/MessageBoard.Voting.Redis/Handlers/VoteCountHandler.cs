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
    public class VoteCountHandler : IRequestHandler<VoteCountQuery, IEnumerable<Vote>>
    {
        private readonly IDatabase _db;

        public VoteCountHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vote>> Handle(VoteCountQuery request, CancellationToken cancellationToken)
        {
            var key = MapKey(request.SubjectId);
            IEnumerable<HashEntry> entries;

            if (request.OptionNames == null || !request.OptionNames.Any())
                entries = await _db.HashGetAllAsync(key);
            else
            {
                var redisOptions = request.OptionNames
                    .Select(o => (RedisValue)o)
                    .ToArray();

                var voteValues = await _db.HashGetAsync(key, redisOptions);
                entries = voteValues.Select((value, index) => new HashEntry(redisOptions[index], value));
            }

            return ToModel(request.SubjectId, entries);
        }
    }
}
