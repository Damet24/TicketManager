using Common.Domain;
using Ticket.Domain.Entities;
using Ticket.Domain.Repositories;

namespace Ticket.Application.Create;

public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    
    public async void Handle(CreateTicketCommand command)
    {
        var ticket = new Domain.Entities.Ticket
        {
            Id = command.Id,
            CreatedAt = DateTime.Now,
            Author = command.Author,
            Type = command.Type,
            Message = command.Message
        };
        await _ticketRepository.Save(ticket);
    }
}