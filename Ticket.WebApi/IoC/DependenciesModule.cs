using Autofac;
using Comman.Infrastructure.CommandBus;
using Common.Domain;
using Serilog;
using Ticket.Application.Create;
using Ticket.Domain.Repositories;
using Ticket.Infrastructure.Persistence;

namespace Ticket.WebApi.IoC;

public class DependenciesModule : InjectionModule
{
    public DependenciesModule(IConfiguration configuration) : base(configuration)
    {
    }

    protected override void PopulateServices(ContainerBuilder builder)
    {
        builder.RegisterType<InMemoryTicketRepository>().As<ITicketRepository>();
        builder.RegisterType<CreateTicketCommandHandler>().As<IEnumerable<ICommandHandler<Command>>>();
        builder.Register((a, _) =>
        {
            var handlers = a.Resolve<IEnumerable<ICommandHandler<Command>>>();
            return new CommandHandlers(handlers);
        }).AsSelf();
    }
}