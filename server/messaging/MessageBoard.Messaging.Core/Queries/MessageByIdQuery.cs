using System;
using MediatR;

namespace MessageBoard.Messaging.Core.Queries
{
    public class MessageByIdQuery : IRequest<Message?>
    {
        public long Id { get; }

        public MessageByIdQuery(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            }

            Id = id;
        }
    }
}
