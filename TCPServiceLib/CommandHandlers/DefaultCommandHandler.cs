using System;
using CommandsLib;

namespace TCPServiceLib
{
    public class DefaultCommandHandler : ICustomCommandHandler
    {
        private TCPService Service { get; set; }
        public DefaultCommandHandler(TCPService service)
        {
            Service = service;
        }

        public object Execute(ICustomCommand command)
        {
            throw new NotSupportedException("No such command.");
        }
    }
}
