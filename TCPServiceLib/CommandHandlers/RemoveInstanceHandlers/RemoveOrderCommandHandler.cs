using CommandsLib;

namespace TCPServiceLib
{
    public class RemoveOrderCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public RemoveOrderCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var removeOrderCommand = (RemoveOrderCommand)command;
            return Service.RemoveOrder(removeOrderCommand.OrdId);
        }
    }
}