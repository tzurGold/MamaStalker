using Client.BLL.Abstractions;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UI.Implementations;

namespace Client.BLL.Implementations
{
    public class TcpClientManager : ClientBase
    {
        private TcpClient _client;

        public TcpClientManager(int port,
            string ip,
            NotifyException notifyException,
            IAction action) 
            : base(port, ip, notifyException, action)
        {
            _client = new TcpClient();
        }

        public override void CommunicateWithServer()
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = null;
            try
            {
                stream = _client.GetStream();

                while (true)
                {
                    byte[] bytes = new byte[1024];
                    stream.Read(bytes, 0, bytes.Length);
                    _action.DoAction(bytes);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }
        }

        public override void Connect()
        {
            _client.Connect(Ip, Port);
        }

        public override void CloseConnection()
        {
            _client.Close();
        }
    }
}
