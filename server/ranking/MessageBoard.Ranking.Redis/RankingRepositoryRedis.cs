using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Ranking.Core;
using StackExchange.Redis;

namespace MessageBoard.Ranking.Redis
{
    public class RankingRepositoryRedis : IRankingRepository
    {
        private readonly IDatabase _db;

        public RankingRepositoryRedis(string host)
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException(nameof(host));

            var connection = ConnectionMultiplexer.Connect(host);
            _db = connection.GetDatabase();
        }

        public Task Increment(string optionName, string subjectId)
        {
            return _db.SortedSetIncrementAsync(RankingKey(optionName), subjectId, 1d);
        }

        public async Task<IEnumerable<VoteCount>> List(string optionName, uint length)
        {
            var items = await _db.SortedSetRangeByScoreWithScoresAsync(RankingKey(optionName),
                order: Order.Descending,
                take: length);

            return items.Select(i => new VoteCount
            {
                Count = (uint)i.Score,
                SubjectId = i.Element
            });
        }

        private string RankingKey(string optionName) => $"ranking:{optionName}";
    }
}
