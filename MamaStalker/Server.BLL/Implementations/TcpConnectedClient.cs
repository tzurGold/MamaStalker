using Server.BLL.Abstraction;
using System.Net.Sockets;

namespace Server.BLL.Implementations
{
    public class TcpConnectedClient : IConnectedClient
    {
        private TcpClient _client;

        public TcpConnectedClient(TcpClient client)
        {
            _client = client;
        }

        public byte[] Receive()
        {
            NetworkStream stream = _client.GetStream();
            byte[] data = new byte[1024];
            stream.Read(data, 0, data.Length);
            return data;
        }

        public void Send(byte[] data)
        {
            NetworkStream stream = _client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}
