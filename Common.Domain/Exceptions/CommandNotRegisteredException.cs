namespace Common.Domain.Exceptions;

public class CommandNotRegisteredException : Exception
{
    public CommandNotRegisteredException (Command command) : base($"The command <{command.GetType()}> hasn't a command handler associated")
    {
    }
}