using System.Collections.Generic;
using System.Linq;
using MessageBoard.Voting.Core;
using StackExchange.Redis;

namespace MessageBoard.Voting.Redis
{
    internal static class Mappings
    {
        public static string MapKey(string id) => $"voting:{id}";

        public static IEnumerable<Vote> ToModel(string subjectId, IEnumerable<HashEntry> entries)
        {
            return entries.Select(e => new Vote
            {
                Count = e.Value.HasValue ? (uint)e.Value : 0,
                OptionName = e.Name,
                SubjectId = subjectId
            });
        }
    }
}