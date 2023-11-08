using Common.Domain;
using Microsoft.AspNetCore.Mvc;
using Ticket.Domain.Entities;
using Ticket.Domain.Enums;
using Ticket.Infrastructure.Dtos.Request;

namespace Ticket.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    public TicketController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    [HttpPost]
    public IActionResult CreateTicket([FromBody] TicketRequest request)
    {
        var command = new CreateTicketCommand
        {
            Author = request.Author,
            Type = request.Type,
            Message = request.Message
        };
        _commandBus.Dispatch(command);
        return Created("", null);
    }
}