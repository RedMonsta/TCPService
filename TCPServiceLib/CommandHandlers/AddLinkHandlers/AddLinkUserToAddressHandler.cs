using CommandsLib;

namespace TCPServiceLib
{
    public class AddLinkUserToAddressHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddLinkUserToAddressHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addLinkUACommand = (AddLinkUserToAddressCommand)command;
            return Service.AddUserToAddress(addLinkUACommand.UserId, addLinkUACommand.AddrId);
        }
    }
}