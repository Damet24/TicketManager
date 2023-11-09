namespace Common.Domain;

public interface ICommandHandler
{
    public Type SubscribedTo();
    public Task Handle(Command command);
}