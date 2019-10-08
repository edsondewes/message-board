using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Commands;
using MessageBoard.Messaging.Core.Queries;

namespace MessageBoard.Messaging.GRPC
{
    public class MessageServiceImpl : MessageService.MessageServiceBase
    {
        private readonly IMediator _mediator;

        public MessageServiceImpl(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<MessageResponse> Create(CreateRequest request, ServerCallContext context)
        {
            var message = await _mediator.Send(new CreateMessageCommand(request.Text));
            return ToResponse(message);
        }

        public override async Task<MessageResponse> Load(LoadRequest request, ServerCallContext context)
        {
            var message = await _mediator.Send(new MessageByIdQuery(request.Id));
            return ToResponse(message);

        }

        public override async Task<ListResponse> LoadBatch(LoadBatchRequest request, ServerCallContext context)
        {
            var messages = await _mediator.Send(new MessageByIdBatchQuery(request.Id));

            var response = new ListResponse();
            response.Messages.Add(messages.Select(ToResponse));
            return response;
        }

        public override async Task<ListResponse> Paginate(PaginateRequest request, ServerCallContext context)
        {
            var from = request.From > 0
                ? request.From as long?
                : null;

            var list = await _mediator.Send(new PaginatedMessagesQuery(from));

            var response = new ListResponse();
            response.Messages.Add(list.Select(ToResponse));
            return response;
        }

        private MessageResponse ToResponse(Message message) => new MessageResponse
        {
            Created = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(message.Created.ToUniversalTime()),
            Id = message.Id,
            Text = message.Text
        };
    }
}