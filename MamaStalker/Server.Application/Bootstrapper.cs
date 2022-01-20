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

            if (_args.Length != 2
                || !int.TryParse(_args[0], out int port)
                || port < _minPort || port > _maxPort
                || !int.TryParse(_args[1], out int refreshInterval)
                || refreshInterval < 0)
            {
                writer.WriteLine("Invalid arguments entered");
                return null;
            }
            NotifyException notifyException = new NotifyException(writer);
            IAction action = new TcpServerAction();
            return serverFactory.CreateServer(port, notifyException, action); 
        }
    }
}
