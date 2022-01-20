namespace Server.BLL.Abstraction
{
    public interface IAction
    {
        void Execute(IConnectedClient connectedClient);
    }
}
