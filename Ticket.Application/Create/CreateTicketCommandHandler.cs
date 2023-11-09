using Common.Domain;
using Ticket.Domain.Entities;
using Ticket.Domain.Repositories;

namespace Ticket.Application.Create;

public class CreateTicketCommandHandler : ICommandHandler
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public Type SubscribedTo()
    {
        return typeof(CreateTicketCommand);
    }

    public async Task Handle(Command command)
    {
        var createTicketCommand = (CreateTicketCommand)command;
        var ticket = new Domain.Entities.Ticket
        {
            Id = createTicketCommand.Id,
            CreatedAt = DateTime.Now,
            Author = createTicketCommand.Author,
            Type = createTicketCommand.Type,
            Message = createTicketCommand.Message
        };
        await _ticketRepository.Save(ticket);
    }
}