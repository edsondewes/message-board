using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.Messaging.Core
{
    public interface IMessageRepository
    {
        Task<Message> Get(long id);
        Task<long> Insert(Message obj);
        Task<IEnumerable<Message>> List(long? from = null, uint pageSize = 10);
    }
}
