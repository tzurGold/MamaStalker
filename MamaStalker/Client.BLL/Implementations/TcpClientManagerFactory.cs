using Client.BLL.Abstractions;
using UI.Implementations;

namespace Client.BLL.Implementations
{
    public class TcpClientFactory : IClientFactory
    {
        public ClientBase CreateClient(int port, string ip, NotifyException notifyException)
        {
            return new TcpClientManager(port, ip, notifyException);
        }
    }
}
