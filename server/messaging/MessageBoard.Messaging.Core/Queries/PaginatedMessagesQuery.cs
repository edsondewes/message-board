using System;
using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class PaginatedMessagesQuery : IRequest<IEnumerable<Message>>
    {
        const uint MaxPageSize = 100;

        public long? From { get; }
        public uint PageSize { get; }

        public PaginatedMessagesQuery(long? from, uint pageSize = 10)
        {
            if (from.HasValue && from.Value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "From Id must be greater than zero");
            }

            if (pageSize > MaxPageSize)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), $"The maximum page size allowed is {MaxPageSize}");
            }

            From = from;
            PageSize = pageSize;
        }
    }
}
