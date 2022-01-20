using UI.Abstractions;
using System;

namespace UI.Implementations
{
    public class ConsoleReader : IInput<string>
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
