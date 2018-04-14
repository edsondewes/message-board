using System.Threading.Tasks;

namespace MessageBoard.Voting.Core
{
    public interface IEventBus
    {
        Task Publish<T>(T obj);
    }
}
