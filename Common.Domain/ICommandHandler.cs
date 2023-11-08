namespace Common.Domain;

public interface ICommandHandler<T>
{
    public void Handle(T command);
}