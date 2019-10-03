using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class MessageByIdBatchQuery : IRequest<IEnumerable<Message>>
    {
        public List<long> Ids { get; }

        public MessageByIdBatchQuery(IEnumerable<long> ids)
        {
            if (ids is null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            Ids = ids.ToList();
        }
    }
}
