using System;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Voting.Core;
using NATS.Client;
using Newtonsoft.Json;

namespace MessageBoard.Voting.Nats
{
    public class EventBusNats : IDisposable, IEventBus
    {
        private readonly IConnection _connection;

        public EventBusNats(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var options = ConnectionFactory.GetDefaultOptions();
            options.Url = url;

            _connection = new ConnectionFactory().CreateConnection(options);
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
