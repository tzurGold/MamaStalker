namespace UI.Abstractions
{
    public interface IInput<T>
    {
        T ReadLine();
    }
}
