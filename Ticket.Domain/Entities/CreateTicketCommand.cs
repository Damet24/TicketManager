
using Common.Domain;
using Ticket.Domain.Enums;

namespace Ticket.Domain.Entities;

public class CreateTicketCommand : Command
{
    public CreateTicketCommand()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public string Id { get; }
    public string Author { set; get; }
    public TicketType Type { set; get; }
    public string Message { set; get; }
}