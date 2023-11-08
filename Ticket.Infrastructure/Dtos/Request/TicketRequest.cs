using System.ComponentModel.DataAnnotations;
using Ticket.Domain.Enums;

namespace Ticket.Infrastructure.Dtos.Request;

public class TicketRequest
{
    [Required]
    public string Author { set; get; }
    [Required]
    public TicketType Type { set; get; }
    [Required]
    [MinLength(20)]
    public string Message { set; get; }
}