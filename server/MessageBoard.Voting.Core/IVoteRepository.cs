using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.Voting.Core
{
    public interface IVoteRepository
    {
        Task<uint> Increment(string subjectId, string optionName);
        Task<IEnumerable<Vote>> List(string subjectId);
    }
}
