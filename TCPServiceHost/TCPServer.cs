using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPServiceHost
{
    public class TCPServer
    {
        private TcpListener Server { get; }
        private Thread ThreadWorker { get; set; }


        public TCPServer(int port)
        {
            //Server = new TcpListener(GetLocalIPAddress(), port);
            Server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            Server.Start();
            BeginClientsAccepting();
            Console.WriteLine("Server started at " + Server.LocalEndpoint);
        }

        private static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void BeginClientsAccepting()
        {
            ThreadWorker = new Thread(AcceptClients);
            ThreadWorker.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                var handler = Server.AcceptTcpClient();
                Console.WriteLine("Client " + handler.Client.RemoteEndPoint + " connected.");
                BeginClientProcessing(handler);
            }
        }

        private void BeginClientProcessing(TcpClient handler)
        {
            var ClientThread = new Thread(ProcessClient);
            ClientThread.Start(handler);
        }

        public void ProcessClient(object obj)
        {
            var client = (TcpClient)obj;
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[256];
                    string data = "";

                    while (stream.DataAvailable || data.Length == 0)
                    {
                        int bytesCount = stream.Read(buffer, 0, buffer.Length);
                        data += Encoding.UTF8.GetString(buffer, 0, bytesCount);
                    }

                    //Здесь нужна обработка данных
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Client " + client.Client.RemoteEndPoint + " disconnected.");
                    break;
                }
            }
        }
    }
}
