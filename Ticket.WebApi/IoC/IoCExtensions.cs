using System.Reflection;
using Autofac;
using Serilog;

namespace Ticket.WebApi.IoC;

public static class IoCExtensions
{
    public static ContainerBuilder RegisterModules(this ContainerBuilder builder, IConfiguration configuration)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.BaseType == typeof(InjectionModule));
        foreach (var type in types)
        {
            var module = (InjectionModule)Activator.CreateInstance(type, configuration)!;
            builder.RegisterModule(module);
        }

        return builder;
    }
    
    public static IConfiguration ConfigureLogger(this IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        return configuration;
    }
}