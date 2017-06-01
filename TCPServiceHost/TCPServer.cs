using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using CommandsLib;
using TCPServiceLib;

namespace TCPServiceHost
{
    public class TCPServer
    {
        private TcpListener Server { get; }
        private Thread ThreadWorker { get; set; }
        private CommunicationSerializer.CommunicationSerializer Serializer { get; }

        public TCPServer(int port)
        {
            Server = new TcpListener(GetLocalIPAddress(), port);
            //Server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            Serializer = new CommunicationSerializer.CommunicationSerializer();
            FillHandlersDictionary();          
            Server.Start();
            BeginClientsAccepting();
            Console.WriteLine("Service started at " + Server.LocalEndpoint);
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

        public void BeginClientsAccepting()
        {
            ThreadWorker = new Thread(AcceptClients);
            ThreadWorker.Start();
        }

        public void EndClientsProcessing()
        {
            ThreadWorker.Abort();
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

                    object response;
                    Exception exception = null;
                    ICustomCommand command = Serializer.Deserialize(data);
                    ICustomCommandHandler commandHandler = CommandHandlersDictionary.GetHandler(command.GetType());

                    try
                    {
                        response = commandHandler.Execute(command);
                    }
                    catch (Exception ex)
                    {
                        response = null;
                        exception = ex;
                    }

                    string serializedResponse = Serializer.Serialize(new Response { Value = response, Exception = exception });
                    byte[] bytesResponse = Encoding.UTF8.GetBytes(serializedResponse);
                    stream.Write(bytesResponse, 0, bytesResponse.Length);

                    Console.WriteLine(client.Client.RemoteEndPoint + " |> " + command.GetType().ToString().Split('.')[1]);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Client " + client.Client.RemoteEndPoint + " disconnected.");
                    break;
                }
            }
        }

        private void FillHandlersDictionary()
        {
            var service = new TCPService();
            CommandHandlersDictionary.AddHandler(new AddUserCommand().GetType(), new AddUserCommandHandler(service));
            CommandHandlersDictionary.AddHandler(new AddAddressCommand().GetType(), new AddAddressCommandHandler(service));
            CommandHandlersDictionary.AddHandler(new AddOrderCommand().GetType(), new AddOrderCommandHandler(service));

            CommandHandlersDictionary.AddHandler(new RemoveUserCommand().GetType(), new RemoveUserCommandHandler(service));
            CommandHandlersDictionary.AddHandler(new RemoveAddressCommand().GetType(), new RemoveAddressCommandHandler(service));
            CommandHandlersDictionary.AddHandler(new RemoveOrderCommand().GetType(), new RemoveOrderCommandHandler(service));

            CommandHandlersDictionary.AddHandler(new AddLinkUserToAddressCommand().GetType(), new AddLinkUserToAddressHandler(service));
            CommandHandlersDictionary.AddHandler(new AddLinkAddressToUserCommand().GetType(), new AddLinkAddressToUserHandler(service));
            CommandHandlersDictionary.AddHandler(new AddLinkOrderToAddressCommand().GetType(), new AddLinkOrderToAddressHandler(service));
            CommandHandlersDictionary.AddHandler(new AddLinkOrderToUserCommand().GetType(), new AddLinkOrderToUserHandler(service));

            CommandHandlersDictionary.AddHandler(new RemoveLinkUserToAddressCommand().GetType(), new RemoveLinkUserToAddressHandler(service));
            CommandHandlersDictionary.AddHandler(new RemoveLinkAddressToUserCommand().GetType(), new RemoveLinkAddressToUserHandler(service));
            CommandHandlersDictionary.AddHandler(new RemoveLinkOrderToAddressCommand().GetType(), new RemoveLinkOrderToAddressHandler(service));
            CommandHandlersDictionary.AddHandler(new RemoveLinkOrderToUserCommand().GetType(), new RemoveLinkOrderToUserHandler(service));

            CommandHandlersDictionary.AddHandler(new GetDataCommand().GetType(), new GetDataCommandHandler(service));

            CommandHandlersDictionary.SetDefaultHandler(new DefaultCommandHandler(service));
        }
    }
}
