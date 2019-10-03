using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Commands;
using StackExchange.Redis;
using static MessageBoard.Messaging.Redis.Mappings;

namespace MessageBoard.Messaging.Redis.Handlers
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, Message>
    {
        private readonly IDatabase _db;

        public CreateMessageHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var newId = await _db.StringIncrementAsync(IdKey);
            await _db.HashSetAsync(MapKey(newId), new HashEntry[]
            {
                new HashEntry(CreatedEntry, request.Created.Ticks),
                new HashEntry(TextEntry, request.Text)
            });

            await _db.SortedSetAddAsync(MessageListKey, member: newId, score: newId);

            return new Message(
                created: request.Created,
                id: newId,
                text: request.Text
                );
        }
    }
}
