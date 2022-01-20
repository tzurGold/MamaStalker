using Client.BLL.Abstractions;
using UI.Implementations;

namespace Client.BLL.Implementations
{
    public class TcpClientManagerFactory : IClientFactory
    {
        public ClientBase CreateClient(int port, string ip, NotifyException notifyException, IAction action)
        {
            return new TcpClientManager(port, ip, notifyException, action);
        }
    }
}
