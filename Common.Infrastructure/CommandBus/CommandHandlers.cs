using Common.Domain;
using Common.Domain.Exceptions;

namespace Comman.Infrastructure.CommandBus;

public class CommandHandlers
{
    private Dictionary<Type, ICommandHandler<Command>> Handlers = new();
    
    public CommandHandlers(IEnumerable<ICommandHandler<Command>> commandHandlers)
    {
        foreach (var commandHandler in commandHandlers)
        {
            Handlers.Add(commandHandler.GetType(), commandHandler);
        }
    }

    public ICommandHandler<Command> Get(Command command)
    {
        var commandHandler = Handlers[command.GetType()];
        if (commandHandler == null)
            throw new CommandNotRegisteredException(command);
        return commandHandler;
    }
}