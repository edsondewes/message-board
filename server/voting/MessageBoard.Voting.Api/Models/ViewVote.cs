using System.Collections.Generic;
using System.Linq;
using MessageBoard.Voting.Core;

namespace MessageBoard.Voting.Api.Models
{
    public class ViewVote
    {
        public static IDictionary<string, uint> From(params Vote[] obj)
        {
            return obj.ToDictionary(key => key.OptionName, value => value.Count);
        }

        public static IDictionary<string, uint> From(IEnumerable<Vote> obj)
        {
            return obj.ToDictionary(key => key.OptionName, value => value.Count);
        }
    }
}
