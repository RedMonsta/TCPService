using CommandsLib;

namespace TCPServiceLib
{
    public class AddUserCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddUserCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addUserCommand = (AddUserCommand)command;
            return Service.AddUser(addUserCommand.Name);
        }
    }
}
