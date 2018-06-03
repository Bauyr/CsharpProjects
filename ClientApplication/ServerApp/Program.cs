using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApplication
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),6556);
			s.Connect(endPoint);

			Console.Write("Enter a MESSAGE : ");
			string message = Console.ReadLine();

			byte[] messagebuffer = Encoding.Default.GetBytes(message);
			s.Send(messagebuffer, 0, messagebuffer.Length, 0);

			byte[] buff = new byte[255];
		    int rec = s.Receive(buff, 0, buff.Length, 0);

			Array.Resize(ref buff, rec);
			Console.WriteLine("Received: {0}", Encoding.Default.GetString(buff));

			s.Close();
			Console.Read();
		}
	}
}
	