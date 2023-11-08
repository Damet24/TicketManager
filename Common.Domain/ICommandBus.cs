namespace Common.Domain;

public interface ICommandBus
{
    public void Dispatch(Command command);
}