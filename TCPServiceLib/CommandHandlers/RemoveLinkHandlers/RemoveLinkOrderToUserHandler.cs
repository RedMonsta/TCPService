using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveLinkOrderToUserHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveLinkOrderToUserHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeLinkOUCommand = (RemoveLinkOrderToUserCommand)command;
            return Service.RemoveOrderFromUser(removeLinkOUCommand.OrdId, removeLinkOUCommand.UserId);
        }
    }
}
