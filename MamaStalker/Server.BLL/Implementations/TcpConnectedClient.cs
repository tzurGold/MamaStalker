using Common.DTOs;
using Server.BLL.Abstraction;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            IFormatter formatter = new BinaryFormatter();
            Person p = (Person)formatter.Deserialize(stream);
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, p);
                return ms.ToArray();
            }
        }

        public void Send(byte[] data)
        {
            NetworkStream stream = _client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}
