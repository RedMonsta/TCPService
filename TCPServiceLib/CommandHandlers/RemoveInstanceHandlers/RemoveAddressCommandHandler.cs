using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveAddressCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveAddressCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeAddressCommand = (RemoveAddressCommand)command;
            return Service.RemoveAddress(removeAddressCommand.AddrId);
        }
    }
}