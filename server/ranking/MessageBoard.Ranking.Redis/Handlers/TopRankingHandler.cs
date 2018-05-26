using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Ranking.Core;
using MessageBoard.Ranking.Core.Queries;
using StackExchange.Redis;
using static MessageBoard.Ranking.Redis.Mappings;

namespace MessageBoard.Ranking.Redis.Handlers
{
    public class TopRankingHandler : IRequestHandler<TopRankingQuery, IEnumerable<VoteCount>>
    {
        private readonly IDatabase _db;

        public TopRankingHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VoteCount>> Handle(TopRankingQuery request, CancellationToken cancellationToken)
        {
            var items = await _db.SortedSetRangeByScoreWithScoresAsync(MapKey(request.OptionName),
                order: Order.Descending,
                take: request.Length);

            return items.Select(i => new VoteCount
            {
                Count = (uint)i.Score,
                SubjectId = i.Element
            });
        }
    }
}
