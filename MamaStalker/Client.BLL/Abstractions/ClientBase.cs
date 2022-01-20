using System;
using UI.Implementations;

namespace Client.BLL.Abstractions
{
    public abstract class ClientBase
    {
        protected readonly int Port;

        protected readonly string Ip;

        protected readonly NotifyException _notifyException;

        public ClientBase(int port, string ip, NotifyException notifyException)
        {
            Port = port;
            Ip = ip;
            _notifyException = notifyException;
        }

        public abstract void Connect();

        public abstract void CommunicateWithServer();

        public abstract void CloseConnection();

        public void Run()
        {
            try
            {
                Connect();
                CommunicateWithServer();
            }
            catch (Exception e)
            {
                _notifyException.Notify(e.ToString());
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
