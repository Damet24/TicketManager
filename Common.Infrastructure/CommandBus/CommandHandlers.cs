using Common.Domain;
using Common.Domain.Exceptions;

namespace Common.Infrastructure.CommandBus;

public class CommandHandlers
{
    private readonly Dictionary<Type, ICommandHandler> _handlers = new();
    
    public CommandHandlers(IEnumerable<ICommandHandler> commandHandlers)
    {
        foreach (var commandHandler in commandHandlers)
        {
            _handlers.Add(commandHandler.SubscribedTo(), commandHandler);
        }
    }

    public ICommandHandler Get(Command command)
    {
        var commandHandler = _handlers[command.GetType()];
        if (commandHandler == null)
            throw new CommandNotRegisteredException(command);
        return commandHandler;
    }
}