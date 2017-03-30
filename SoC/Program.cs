using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = 2000;
            var host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipep = new IPEndPoint(ip, port);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Client Conntent...");
            s.Connect(ipep);

            var sendStr = "hehe";
            byte[] bytes = Encoding.ASCII.GetBytes(sendStr);
            s.Send(bytes, bytes.Length, 0);

            var recStr = "";
            byte[] recStrs = new byte[1024];
            s.Receive(recStrs, recStrs.Length, 0);
            recStr += Encoding.ASCII.GetString(recStrs);
            Console.WriteLine("Client Recive Message:" + recStr);
            s.Close();
            Console.ReadLine();
        }
    }
}
