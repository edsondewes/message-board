using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.GraphQL.Model
{
    public interface IRepository
    {
        Task<Vote> AddVote(AddVoteModel model);
        Task<Message> CreateMessage(CreateMessageModel model);

        Task<IDictionary<long, Message>> ListMessages(IEnumerable<long> ids);
        Task<IEnumerable<MessageRanking>> ListMessagesByRanking(string optionName);
        Func<IEnumerable<string>, Task<IDictionary<string, IEnumerable<Vote>>>> ListVotes(IEnumerable<string> optionNames = null);
        Task<IEnumerable<Message>> PaginateMessages(long? from);
    }
}