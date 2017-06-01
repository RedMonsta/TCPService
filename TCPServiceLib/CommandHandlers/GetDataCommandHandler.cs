using CommandsLib;

namespace TCPServiceLib
{
    public class GetDataCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public GetDataCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            return Service.GetData();
        }
    }
}
