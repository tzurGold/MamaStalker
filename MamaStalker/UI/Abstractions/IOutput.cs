namespace UI.Abstractions
{
    public interface IOutput<T>
    {
        void WriteLine(T output);
    }
}
