using Client.BLL.Abstractions;

namespace Client.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            ClientBase client = bootstrapper.Initialize();

            client.Run();
        }
    }
}
