using Server.BLL.Abstraction;
using UI.Implementations;

namespace Server.BLL.Implementations
{
    public class TcpServerFactory : IServerFactory
    {
        public ServerBase CreateServer(int port, NotifyException notifyException, IAction action)
        {
            return new TcpServer(port, notifyException, action);
        }
    }
}
