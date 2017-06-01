using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveLinkAddressToUserHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveLinkAddressToUserHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeLinkAUCommand = (RemoveLinkAddressToUserCommand)command;
            return Service.RemoveAddressFromUser(removeLinkAUCommand.AddrId, removeLinkAUCommand.UserId);
        }
    }
}