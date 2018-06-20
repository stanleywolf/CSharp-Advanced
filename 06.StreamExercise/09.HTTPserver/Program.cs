using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _09.HTTPserver
{
    class Program
    {
        private const int PortNumber = 1337;
        private const string httpOk = "HTTP/1.1 200 OK\nContent-Type:text\n\n";
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...",PortNumber);
            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    stream.Read(request, 0, 4096);
                    Console.WriteLine(Encoding.UTF8.GetString(request));

                    string html = string.Format(httpOk + "{1}{2}{3} <br>{4}{2}{1}{0}", "<html>",
                        "<body>", "<h1>", "Welcome to my site", DateTime.Now);
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);

                    stream.Write(htmlBytes,0,htmlBytes.Length);
                }
            }
        }
    }
}
