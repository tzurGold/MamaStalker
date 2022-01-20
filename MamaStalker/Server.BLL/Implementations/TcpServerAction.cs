using Common.DTOs;
using Server.BLL.Abstraction;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Server.BLL.Implementations
{
    public class TcpServerAction : IAction
    {

        private readonly int _refreshInterval;

        public TcpServerAction(int refreshInterval)
        {
            _refreshInterval = refreshInterval;
        }

        public void Execute(IConnectedClient connectedClient)
        {
            try
            {
                while (true)
                {
                    IFormatter formatter = new BinaryFormatter();
                    MemoryStream memoryStream = new MemoryStream();
                    byte[] data = connectedClient.Receive();
                    memoryStream.Write(data, 0, data.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    Person p = (Person)formatter.Deserialize(memoryStream);
                    Console.WriteLine(p);

                    memoryStream = new MemoryStream();
                    formatter.Serialize(memoryStream, p);
                    data = memoryStream.ToArray();
                    connectedClient.Send(data);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
