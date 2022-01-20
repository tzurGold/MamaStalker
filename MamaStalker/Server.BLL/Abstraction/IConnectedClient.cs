namespace Server.BLL.Abstraction
{
    public interface IConnectedClient
    {
        void Send(byte[] data);
        byte[] Receive();
    }
}
