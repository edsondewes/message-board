using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class PaginatedMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public long? From { get; }
        public uint PageSize { get; }

        public PaginatedMessagesQuery(long? from, uint pageSize = 10)
        {
            From = from;
            PageSize = pageSize;
        }
    }
}
