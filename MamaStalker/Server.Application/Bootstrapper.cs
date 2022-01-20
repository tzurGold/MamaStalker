using Server.BLL.Abstraction;
using Server.BLL.Implementations;
using UI.Abstractions;
using UI.Implementations;

namespace Server.Application
{
    public class Bootstrapper
    {
        private readonly string[] _args;
        private const int _minPort = 0;
        private const int _maxPort = 65536;

        public Bootstrapper(string[] args)
        {
            _args = args;
        }

        public ServerBase Initialize()
        {
            IServerFactory serverFactory = new TcpServerFactory();
            IOutput<string> writer = new ConsoleWriter();
            int port = 0;
            if(_args.Length != 1 || !int.TryParse(_args[0], out port) || port < _minPort || port > _maxPort)
            {
                writer.WriteLine("Invalid port entered");
                return null;
            }
            NotifyException notifyException = new NotifyException(writer);
            IAction action = new TcpServerAction();
            return serverFactory.CreateServer(port, notifyException, action); 
        }
    }
}
