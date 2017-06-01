using CommandsLib;

namespace TCPServiceLib
{
    public class AddAddressCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddAddressCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addAddressCommand = (AddAddressCommand)command;
            return Service.AddAddress(addAddressCommand.City, addAddressCommand.Street, addAddressCommand.Build, addAddressCommand.Flat);
        }
    }
}
