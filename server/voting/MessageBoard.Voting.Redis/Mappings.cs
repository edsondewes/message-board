using System.Collections.Generic;
using System.Linq;
using MessageBoard.Voting.Core;
using StackExchange.Redis;

namespace MessageBoard.Voting.Redis
{
    internal static class Mappings
    {
        public static string MapKey(string id) => $"voting:{id}";

        public static IEnumerable<Vote> ToModel(string subjectId, HashEntry[] entries)
        {
            return entries.Select(e => new Vote
            {
                Count = (uint)e.Value,
                OptionName = e.Name,
                SubjectId = subjectId
            });
        }
    }
}