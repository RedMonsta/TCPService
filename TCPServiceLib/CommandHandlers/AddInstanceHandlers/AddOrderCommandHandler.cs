using CommandsLib;

namespace TCPServiceLib
{ 
    public class AddOrderCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public AddOrderCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            var addOrderCommand = (AddOrderCommand)command;
            return Service.AddOrder(addOrderCommand.GoodName);
        }
    }
}
