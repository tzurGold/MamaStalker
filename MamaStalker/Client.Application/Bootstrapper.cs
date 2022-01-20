using Client.BLL.Abstractions;
using Client.BLL.Implementations;
using Common;
using UI.Abstractions;
using UI.Implementations;

namespace Client.Application
{
    public class Bootstrapper
    {
        private const int _minPort = 0;
        private const int _maxPort = 65536;

        public ClientBase Initialize()
        {
            IClientFactory clientFactory = new TcpClientManagerFactory();
            IOutput<string> writer = new ConsoleWriter();
            IInput<string> reader = new ConsoleReader();
            NotifyException notifyException = new NotifyException(writer);
            int port = -1;
            string ip = string.Empty;
            while(port < _minPort || port > _maxPort)
            {
                writer.WriteLine("Enter ip:port");
                string input = reader.ReadLine();
                ip = input.Substring(0, input.IndexOf(":"));
                port = int.Parse(input.Substring(input.IndexOf(":") + 1));
            }
            IAction action = new ClientAction(new Parser());
            return clientFactory.CreateClient(port, ip, notifyException, action); 
        }
    }
}
