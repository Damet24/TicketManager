using Ticket.Domain.Repositories;

namespace Ticket.Infrastructure.Persistence;

public class InMemoryTicketRepository : ITicketRepository
{
    public Task Save(Domain.Entities.Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Ticket?> Get(string id)
    {
        throw new NotImplementedException();
    }
}