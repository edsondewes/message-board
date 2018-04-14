using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.Ranking.Core
{
    public interface IRankingRepository
    {
        Task Increment(string optionName, string subjectId);
        Task<IEnumerable<VoteCount>> List(string optionName, uint length);
    }
}
