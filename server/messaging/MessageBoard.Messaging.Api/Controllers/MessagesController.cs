using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Messaging.Api.Models;
using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Core.Commands;
using MessageBoard.Messaging.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoard.Messaging.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Message>> Get([FromQuery]long? from)
        {
            var result = await _mediator.Send(new PaginatedMessagesQuery(from));
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Message> GetId([FromRoute]long id)
        {
            var result = await _mediator.Send(new MessageByIdQuery(id));
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post([FromBody]CreateMessageModel model)
        {
            var message = await _mediator.Send(new CreateMessageCommand(model.Text));
            return message;
        }
    }
}
