using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveUserCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveUserCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeUserCommand = (RemoveUserCommand)command;
            return Service.RemoveUser(removeUserCommand.UserId);
        }
    }
}
