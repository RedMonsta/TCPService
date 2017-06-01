using CommandsLib;

namespace TCPServiceLib
{
    public class AddLinkOrderToAddressHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddLinkOrderToAddressHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addLinkOACommand = (AddLinkOrderToAddressCommand)command;
            return Service.AddOrderToAddress(addLinkOACommand.OrdId, addLinkOACommand.AddrId);
        }
    }
}