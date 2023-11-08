namespace Ticket.Domain.Repositories;

public interface ITicketRepository
{
    public Task Save(Entities.Ticket ticket);
    public Task<Entities.Ticket?> Get(string id);
}