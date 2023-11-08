using Ticket.Domain.Enums;

namespace Ticket.Domain.Entities;

public record Ticket
{
    public string Id { set; get; }
    public DateTime CreatedAt { set; get; }
    public string Author { set; get; }
    public TicketType Type { set; get; }
    public string Message { set; get; }
}
