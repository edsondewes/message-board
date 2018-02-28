using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Messaging.Core.Commands
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, Message>
    {
        private IMessageRepository _repository;

        public CreateMessageHandler(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var obj = new Message
            {
                Created = DateTime.Now,
                Text = request.Text
            };

            var id = await _repository.Insert(obj);
            obj.Id = id;
            return obj;
        }
    }
}
