using CommandsLib;

namespace TCPServiceLib
{
    public class AddLinkAddressToUserHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddLinkAddressToUserHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addLinkAUCommand = (AddLinkAddressToUserCommand)command;
            return Service.AddAddressToUser(addLinkAUCommand.AddrId, addLinkAUCommand.UserId);
        }
    }
}