using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8888);
            server.Start();
            Console.WriteLine("server started and waiting for client");
            Socket socketforclients = server.AcceptSocket();

            if(socketforclients.Connected)
            {
                // send message to client
                NetworkStream ns = new NetworkStream(socketforclients);
                StreamWriter sw = new StreamWriter(ns);
                Console.WriteLine("Server >> Welcome Client ");
                sw.WriteLine("Welcome Client");

                sw.Flush();
                // get message from client
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine("Client >> " + sr.ReadLine());
                sw.Close();
                ns.Close();
            }

            socketforclients.Close();
            Console.ReadLine();
        }
    }
}
