using System.Threading.Tasks;

namespace MessageBoard.Voting.Nats
{
    public interface IEventBus
    {
        Task Publish<T>(T obj);
    }
}