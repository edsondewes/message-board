using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Messaging.Core;
using StackExchange.Redis;

namespace MessageBoard.Messaging.Redis
{
    public class MessageRepositoryRedis : IMessageRepository
    {
        private const string IdKey = "message:id";
        private const string MessageListKey = "messages";

        private const string CreatedEntry = "created";
        private const string TextEntry = "text";

        private readonly IDatabase _db;

        public MessageRepositoryRedis(string host)
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException(nameof(host));

            var connection = ConnectionMultiplexer.Connect(host);
            _db = connection.GetDatabase();
        }

        public async Task<Message> Get(long id)
        {
            var entries = await _db.HashGetAllAsync(ItemKey(id));
            var dictionary = entries.ToDictionary();

            return new Message
            {
                Created = new DateTime((long)dictionary[CreatedEntry]),
                Id = (long)id,
                Text = dictionary[TextEntry]
            };
        }

        public async Task<long> Insert(Message obj)
        {
            var newId = await _db.StringIncrementAsync(IdKey);
            await _db.HashSetAsync(ItemKey(newId), new HashEntry[]
            {
                new HashEntry(CreatedEntry, DateTime.Now.Ticks),
                new HashEntry(TextEntry, obj.Text)
            });

            await _db.SortedSetAddAsync(MessageListKey, member: newId, score: newId);

            return newId;
        }

        public async Task<IEnumerable<Message>> List(uint? from = null, uint pageSize = 10)
        {
            var ids = await _db.SortedSetRangeByScoreAsync(MessageListKey,
                stop: from ?? double.PositiveInfinity,
                exclude: from.HasValue ? Exclude.Stop : Exclude.None,
                order: Order.Descending,
                take: pageSize);

            var list = await Task.WhenAll(
                    ids.Select(id => Get((long)id))
                );

            return list;
        }

        private string ItemKey(long id) => ItemKey(id.ToString());
        private string ItemKey(string id) => $"message:{id}";
    }
}
