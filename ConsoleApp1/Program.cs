using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static IPEndPoint ipep; // Địa chỉ IP dùng để kết nối
        static Socket server;

        class Client
        {
            public Socket address;
            public String name;
        }

        static List<Client> clientList;

        static void Main(string[] args)
        {
            clientList = new List<Client>();
            ipep = new IPEndPoint(IPAddress.Any, 5000); // Khai bao 1 dia chi IP va cong
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(ipep);

            Console.WriteLine("Waiting to connect...");

            Connect();


        }

        static void Connect()
        {
            String welcomeMessage = "---------------WELCOME TO CHAT ROOM!---------------";


            try
            {
                while (true)
                {

                    server.Listen(100);

                    Client activeClient = new Client();
                    activeClient.address = server.Accept();

                    clientList.Add(activeClient);

                    byte[] datarecv = new byte[1024];
                    int recv = activeClient.address.Receive(datarecv);
                    activeClient.name = Encoding.ASCII.GetString(datarecv, 0, recv);

                    Console.WriteLine("Accept connect with: {0}", activeClient.address.RemoteEndPoint.ToString());

                    byte[] datasend = new byte[1024];
                    datasend = Encoding.ASCII.GetBytes(welcomeMessage);
                    //activeClient.address.Send(datasend, datasend.Length, SocketFlags.None);

                    //Notification(activeClient.name + " has joined the conversation", activeClient.address);

                    Thread Receive = new Thread(ReceiveMessage);
                    Receive.IsBackground = true;
                    Receive.Start(activeClient);

                }

            }
            catch
            {
                ipep = new IPEndPoint(IPAddress.Any, 5000); // Khai bao 1 dia chi IP va cong
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

        }

        static void ReceiveMessage(Object obj)
        {
            Client client = obj as Client;

            byte[] datarecv = new byte[1024];

            int recv;
            try
            {
                while (true)
                {
                    recv = client.address.Receive(datarecv);
                    String message = Encoding.ASCII.GetString(datarecv, 0, recv);

                    SendMessage(null, message);


                }
            }
            catch
            {
                clientList.Remove(client);
                Console.WriteLine(client.address.RemoteEndPoint.ToString() + " has disconnected.");

                //Notification(client.name + " has left the conversation", client.address);

                client.address.Close();
            }
        }

        static void SendMessage(Socket clientSend, String text)
        {
            byte[] datasend = new byte[1024];

            datasend = Encoding.ASCII.GetBytes(text);

            foreach (Client item in clientList)
            {
                if (item.address != null && item.address != clientSend)
                {
                    item.address.Send(datasend, datasend.Length, SocketFlags.None);
                }
            }
        }

        static void Notification(String text, Socket exceptClient)
        {
            text = "&&" + text;
            SendMessage(exceptClient, text);
        }
    }
}
