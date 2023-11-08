using Autofac;

namespace Ticket.WebApi.IoC;

public abstract class InjectionModule : Module
{
    protected readonly IConfiguration Configuration;

    protected InjectionModule(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        PopulateClients(builder);
        PopulateRepositories(builder);
        PopulateServices(builder);
    }

    protected virtual void PopulateClients(ContainerBuilder builder)
    {
    }

    protected virtual void PopulateRepositories(ContainerBuilder builder)
    {
    }

    protected virtual void PopulateServices(ContainerBuilder builder)
    {
    }
}