using Server.BLL.Abstraction;
using System.Net;
using System.Net.Sockets;
using UI.Implementations;

namespace Server.BLL.Implementations
{
    public class TcpServer : ServerBase
    {

        private TcpListener _listener;

        public TcpServer(int port, NotifyException notifyException, IAction action)
            : base(port, notifyException, action)
        {

        }

        protected override void CloseConnection()
        {
            _listener.Stop();
        }

        protected override IConnectedClient Connect()
        {
            TcpClient client = _listener.AcceptTcpClient();
            return new TcpConnectedClient(client);
        }

        protected override void Listen()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(localAddr, Port);
            _listener.Start();
        }
    }
}
