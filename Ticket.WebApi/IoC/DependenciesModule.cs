using Autofac;
using Common.Infrastructure.CommandBus;
using Common.Domain;
using Ticket.Application.Create;
using Ticket.Domain.Repositories;
using Ticket.Infrastructure.Persistence;

namespace Ticket.WebApi.IoC;

public class DependenciesModule : InjectionModule
{
    public DependenciesModule(IConfiguration configuration) : base(configuration)
    {
    }
    
    protected override void PopulateRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<InMemoryTicketRepository>().As<ITicketRepository>();
    }

    protected override void PopulateCommands(ContainerBuilder builder)
    {
        builder.RegisterType<CreateTicketCommandHandler>().As<ICommandHandler>();
    }

    protected override void PopulateServices(ContainerBuilder builder)
    {
        builder.Register((context) =>
        {
            var handlers = context.Resolve<IEnumerable<ICommandHandler>>();
            return new CommandHandlers(handlers);
        }).AsSelf();
        builder.RegisterType<InMemoryCommandBus>().As<ICommandBus>();
    }
}