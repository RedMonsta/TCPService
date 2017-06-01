using CommandsLib;

namespace TCPServiceLib
{
    public class AddLinkOrderToUserHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddLinkOrderToUserHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addLinkOUCommand = (AddLinkOrderToUserCommand)command;
            return Service.AddOrderToUser(addLinkOUCommand.OrdId, addLinkOUCommand.UserId);
        }
    }
}