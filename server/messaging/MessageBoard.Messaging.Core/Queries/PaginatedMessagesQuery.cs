using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class PaginatedMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public uint? From { get; }

        public PaginatedMessagesQuery(uint? from)
        {
            From = from;
        }
    }
}
