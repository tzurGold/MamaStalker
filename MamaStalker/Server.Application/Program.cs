using Server.BLL.Abstraction;

namespace Server.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper(args);

            ServerBase server = bootstrapper.Initialize();

            server?.Run();
        }
    }
}
