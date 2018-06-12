using System.Linq;
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

        public override async Task<ListResponse> List(ListRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var from = request.From > 0
                    ? request.From as long?
                    : null;

                var list = await mediator.Send(new PaginatedMessagesQuery(from));

                var response = new ListResponse();
                response.Messages.AddRange(list.Select(ToResponse));
                return response;
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
            Created = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(message.Created.ToUniversalTime()),
            Id = message.Id,
            Text = message.Text
        };
    }
}