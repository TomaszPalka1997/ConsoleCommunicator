using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SerwerConsoleCommunicator
{
    class Serwer
    {
        private static ManualResetEvent done = new ManualResetEvent(false);

        public class StateObject
        {
            public Socket workSocket = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
            public StringBuilder sb = new StringBuilder();
        }
        public Serwer()
        {
            IPAddress address = IPAddress.Parse("127.0.0.5");
            IPEndPoint localEndPoint = new IPEndPoint(address, 5001);
            Socket serwerSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Start(serwerSocket, localEndPoint);
        }

        public void Start(Socket serwerSocket, IPEndPoint localEndPoint)
        {
            try
            {
                serwerSocket.Bind(localEndPoint);
                serwerSocket.Listen(100);

                while (true)
                {
                    done.Reset();
                    //Logs.ShowLog(LogType.INFO, "Waiting for a incomming connection...");
                    serwerSocket.BeginAccept(new AsyncCallback(AcceptCallback), serwerSocket);
                    done.WaitOne();

                }

            }
            catch (Exception e)
            {

            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            //done.Set();

            Socket serwerSocketListener = (Socket)ar.AsyncState;
            Socket serwerSocketHandler = serwerSocketListener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = serwerSocketHandler;
            serwerSocketHandler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        private void ReadCallback(IAsyncResult ar)
        {

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = null;
            handler = state.workSocket;


            try
            {
                int read = handler.EndReceive(ar);
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, read));
                var content = state.sb.ToString();


                //Send(handler, content);
                Console.WriteLine(content);
                state.sb.Clear();
                handler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception)
            {

            }
        }

        private void Send(Socket handler, string content)
        {
            byte[] data = Encoding.ASCII.GetBytes(content);
            handler.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int sent = handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
