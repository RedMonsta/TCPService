using System;

namespace TCPServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpServer = new TCPServer(17777);
            Console.ReadKey();
            tcpServer.EndClientsProcessing();
        }
    }
}
