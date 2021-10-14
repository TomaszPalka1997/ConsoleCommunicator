using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleCommunicator
{

    class ConsoleCommunicator
    {

        public class StateObject
        {
            public Socket workSocket = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
            public StringBuilder sb = new StringBuilder();
            //private ManualResetEvent allDone = new ManualResetEvent(false);
        }
        public ConsoleCommunicator()
        {
            IPAddress SerwerAddress = IPAddress.Parse("127.0.0.5");
            //IPEndPoint localEndPoint = new IPEndPoint(address, 5001);
            Socket serwerSocket = new Socket(SerwerAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serwerSocket.Connect(new IPEndPoint(SerwerAddress, 5001));
            Send(serwerSocket, "hiiii");
        }

        private void Send(Socket hostSocket, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            hostSocket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), hostSocket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket hostSocket = (Socket)ar.AsyncState;
                int byteSent = hostSocket.EndSend(ar);
                //allDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


    }
}
