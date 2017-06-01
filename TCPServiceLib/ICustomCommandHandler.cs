namespace TCPServiceLib
{
    public interface ICustomCommandHandler
    {
        object Execute(CommandsLib.ICustomCommand command);
    }
}
