using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ClassUsuario;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("172.17.76.230"), 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);

            newsock.Listen(10);

            Console.WriteLine("Waiting for a client...");

            Socket client = newsock.Accept();

            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Conectado com {0} na porta {1}", clientep.Address, clientep.Port);

            string welcome = "Bem vindo ao Servidor";

            data = Encoding.UTF8.GetBytes(welcome);

            client.Send(data, data.Length, SocketFlags.None);

            string input;

            while (true)
            {

                data = new byte[1024];
                recv = client.Receive(data);
                if (recv == 0)
                    break;

                Console.WriteLine("Client: "+Encoding.UTF8.GetString(data, 0, recv));
                input = Console.ReadLine();
                Console.WriteLine("You: " + input);
                client.Send(Encoding.UTF8.GetBytes(input));
            }

            Console.WriteLine("Disconnected from {0}", clientep.Address);
            client.Close();
            newsock.Close();
            Console.ReadLine();

        }
    }
}