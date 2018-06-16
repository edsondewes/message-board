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

        public override async Task<MessageResponse> Load(LoadRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var message = await mediator.Send(new MessageByIdQuery(request.Id));
                return ToResponse(message);
            }
        }

        public override async Task<ListResponse> LoadBatch(LoadBatchRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var messages = await mediator.Send(new MessageByIdBatchQuery(request.Id));

                var response = new ListResponse();
                response.Messages.Add(messages.Select(ToResponse));
                return response;
            }
        }

        public override async Task<ListResponse> Paginate(PaginateRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var from = request.From > 0
                    ? request.From as long?
                    : null;

                var list = await mediator.Send(new PaginatedMessagesQuery(from));

                var response = new ListResponse();
                response.Messages.Add(list.Select(ToResponse));
                return response;
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