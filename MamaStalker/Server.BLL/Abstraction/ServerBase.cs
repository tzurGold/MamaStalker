using System;
using System.Threading.Tasks;
using UI.Implementations;

namespace Server.BLL.Abstraction
{
    public abstract class ServerBase
    {
        protected readonly int Port;
        protected readonly NotifyException ServerNotifyException;
        protected readonly IAction ServerAction;

        public ServerBase(int port, NotifyException notifyException, IAction action)
        {
            Port = port;
            ServerNotifyException = notifyException;
            ServerAction = action;
        }

        public void Run()
        {
            try
            {
                Listen();
                while (true)
                {
                    IConnectedClient connectedClient = Connect();
                    Task.Run(() => ServerAction.Execute(connectedClient));
                }
            }
            catch (Exception e)
            {
                ServerNotifyException.Notify(e.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }

        protected abstract void Listen();

        protected abstract IConnectedClient Connect();

        protected abstract void CloseConnection();
    }
}
