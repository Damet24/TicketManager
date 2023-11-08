using Common.Domain;

namespace Comman.Infrastructure.CommandBus;

public class InMemoryCommandBus : ICommandBus
{
    private readonly CommandHandlers _commandHandlers;

    public InMemoryCommandBus(CommandHandlers commandHandlers)
    {
        _commandHandlers = commandHandlers;
    }

    public void Dispatch(Command command)
    {
        var handler = _commandHandlers.Get(command);
        handler.Handle(command);
    }
}