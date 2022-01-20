using UI.Abstractions;

namespace UI.Implementations
{
    public class NotifyException
    {
        private IOutput<string> _writer;

        public NotifyException(IOutput<string> writer)
        {
            _writer = writer;
        }

        public void Notify(string message)
        {
            _writer.WriteLine(message);
        }
    }
}
