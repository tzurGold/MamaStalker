using Client.BLL.Abstractions;
using Common.DTOs;
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

        public TcpClientManager(int port, string ip, NotifyException notifyException) 
            : base(port, ip, notifyException)
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

                while(true)
                {
                    formatter.Serialize(stream, GetPerson());

                    Person p = (Person)formatter.Deserialize(stream);

                    Console.WriteLine("Received: {0}", p);
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

        private Person GetPerson()
        {
            Console.WriteLine("Enter name:age");
            string input = Console.ReadLine();
            return new Person(input.Substring(0, input.IndexOf(":")), 
                int.Parse(input.Substring(input.IndexOf(":") + 1)));
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
