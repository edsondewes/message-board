using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.GraphQL.Model
{
    public interface IRepository
    {
        Task<Vote> AddVote(AddVoteModel model);
        Task<Message> CreateMessage(CreateMessageModel model);

        Task<Message> GetMessage(long id);
        Task<IEnumerable<Message>> ListMessages(long? from);
        Task<IEnumerable<MessageRanking>> ListMessagesByRanking(string optionName);
        Task<IEnumerable<Vote>> ListVotes(string subjectId, string optionName = null);
    }
}