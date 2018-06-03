using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApplication
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			
			Socket s= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6556);
			s.Bind(endpoint); s.Listen(0);

			Socket accept = s.Accept();

			byte[] messagebuffer = Encoding.Default.GetBytes("Hello My Friend!");
			accept.Send(messagebuffer,0,messagebuffer.Length,0);

			byte[] buff = new byte[255];	
			int rec = accept.Receive(buff, 0, buff.Length, 0);

			Array.Resize(ref buff, rec);

			Console.WriteLine("Received: {0}", Encoding.Default.GetString(buff));

			s.Close();
			accept.Close();

			Console.Read();
		}
	}
}
