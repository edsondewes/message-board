using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> Get([FromQuery]long? from)
        {
            try
            {
                var result = await _mediator.Send(new PaginatedMessagesQuery(from));
                return result.ToList();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetId([FromRoute]long id)
        {
            try
            {
                var result = await _mediator.Send(new MessageByIdQuery(id));
                if (result is null)
                {
                    return NotFound("Id not fount");
                }

                return result;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post([FromBody]CreateMessageModel model)
        {
            var message = await _mediator.Send(new CreateMessageCommand(model.Text));
            return message;
        }
    }
}
