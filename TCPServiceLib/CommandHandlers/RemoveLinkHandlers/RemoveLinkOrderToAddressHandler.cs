using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveLinkOrderToAddressHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveLinkOrderToAddressHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeLinkOACommand = (RemoveLinkOrderToAddressCommand)command;
            return Service.RemoveOrderFromAddress(removeLinkOACommand.OrdId, removeLinkOACommand.AddrId);
        }
    }
}