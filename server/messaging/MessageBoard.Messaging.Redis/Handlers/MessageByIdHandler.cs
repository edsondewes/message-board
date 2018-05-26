using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Queries;
using StackExchange.Redis;
using static MessageBoard.Messaging.Redis.Mappings;

namespace MessageBoard.Messaging.Redis.Handlers
{
    public class MessageByIdHandler : IRequestHandler<MessageByIdQuery, Message>
    {
        private readonly IDatabase _db;

        public MessageByIdHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<Message> Handle(MessageByIdQuery request, CancellationToken cancellationToken)
        {
            var entries = await _db.HashGetAllAsync(MapKey(request.Id));
            var dictionary = entries.ToDictionary();

            return new Message
            {
                Created = new DateTime((long)dictionary[CreatedEntry]),
                Id = (long)request.Id,
                Text = dictionary[TextEntry]
            };
        }
    }
}
