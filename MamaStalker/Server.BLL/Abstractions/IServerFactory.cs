using UI.Implementations;

namespace Server.BLL.Abstraction
{
    public interface IServerFactory
    {
        ServerBase CreateServer(int port, NotifyException notifyException, IAction action);
    }
}
