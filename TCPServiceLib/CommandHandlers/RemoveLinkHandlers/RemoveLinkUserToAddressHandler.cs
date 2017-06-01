using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveLinkUserToAddressHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveLinkUserToAddressHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeLinkUACommand = (RemoveLinkUserToAddressCommand)command;
            return Service.RemoveUserFromAddress(removeLinkUACommand.UserId, removeLinkUACommand.AddrId);
        }
    }
}
