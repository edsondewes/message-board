using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.Messaging.Core
{
    public interface IMessageRepository
    {
        Task<long> Insert(Message obj);
        Task<IEnumerable<Message>> List(uint? from = null, uint pageSize = 10);
    }
}
