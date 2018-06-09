using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Commands;
using MessageBoard.Messaging.Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Messaging.GRPC
{
    public class MessageServiceImpl : MessageService.MessageServiceBase
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public MessageServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task<MessageResponse> Create(CreateRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var message = await mediator.Send(new CreateMessageCommand(request.Text));
                return ToResponse(message);
            }
        }

        public override async Task List(ListRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var from = request.From > 0
                    ? request.From as long?
                    : null;

                var list = await mediator.Send(new PaginatedMessagesQuery(from));
                foreach (var item in list)
                {
                    await responseStream.WriteAsync(ToResponse(item));
                }
            }
        }

        public override async Task<MessageResponse> Single(SingleRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var message = await mediator.Send(new MessageByIdQuery(request.Id));
                return ToResponse(message);
            }
        }

        private MessageResponse ToResponse(Message message) => new MessageResponse
        {
            Created = message.Created.Ticks,
            Id = message.Id,
            Text = message.Text
        };
    }
}