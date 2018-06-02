using System;
using System.Text;
using System.Threading.Tasks;
using NATS.Client;
using Newtonsoft.Json;

namespace MessageBoard.Voting.Nats
{
    public class EventBusNats : IDisposable, IEventBus
    {
        private readonly IConnection _connection;

        public EventBusNats(IConnection connection)
        {
            _connection = connection;
        }

        public Task Publish<T>(T obj)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            _connection.Publish(typeof(T).Name, bytes);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
