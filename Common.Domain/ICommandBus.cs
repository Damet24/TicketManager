namespace Common.Domain;

public interface ICommandBus
{
    public Task Dispatch(Command command);
}