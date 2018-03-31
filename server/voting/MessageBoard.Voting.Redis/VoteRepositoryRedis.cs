using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Voting.Core;
using StackExchange.Redis;

namespace MessageBoard.Voting.Redis
{
    public class VoteRepositoryRedis : IVoteRepository
    {
        private readonly IDatabase _db;

        public VoteRepositoryRedis(string host)
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException(nameof(host));

            var connection = ConnectionMultiplexer.Connect(host);
            _db = connection.GetDatabase();
        }

        public async Task<uint> Increment(string subjectId, string optionName)
        {
            var count = await _db.HashIncrementAsync(ItemKey(subjectId), optionName);
            return (uint)count;
        }

        public async Task<IEnumerable<Vote>> List(string subjectId)
        {
            var entries = await _db.HashGetAllAsync(ItemKey(subjectId));
            return entries.Select(e => new Vote
            {
                Count = (uint)e.Value,
                OptionName = e.Name,
                SubjectId = subjectId
            });
        }

        private string ItemKey(string id) => $"voting:{id}";
    }
}
