using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace So
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 2000;
            string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipep = new IPEndPoint(ip, port);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ipep);
            s.Listen(0);
            Console.WriteLine("Wating...");

            Socket temp = s.Accept();
            Console.Write("Connecting...");

            string recStr = "";
            byte[] recBytes = new byte[1024];
            int bytes;
            bytes = temp.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            Console.WriteLine("Recive:" + recStr);

            var returnStr = "Return String";
            var _byte = Encoding.ASCII.GetBytes(returnStr);
            temp.Send(_byte, _byte.Length, 0);
            temp.Close();
            s.Close();
            Console.ReadLine();
        }
    }
}
