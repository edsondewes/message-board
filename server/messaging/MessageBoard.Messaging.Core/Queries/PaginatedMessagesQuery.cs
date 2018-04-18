using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class PaginatedMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public long? From { get; }

        public PaginatedMessagesQuery(long? from)
        {
            From = from;
        }
    }
}
