using Common.Infrastructure.CommandBus;
using Common.Domain;

namespace Common.Infrastructure.CommandBus;

public class InMemoryCommandBus : ICommandBus
{
    private readonly CommandHandlers _commandHandlers;

    public InMemoryCommandBus(CommandHandlers commandHandlers)
    {
        _commandHandlers = commandHandlers;
    }

    public async Task Dispatch(Command command)
    {
        var handler = _commandHandlers.Get(command);
        await handler.Handle(command);
    }
}