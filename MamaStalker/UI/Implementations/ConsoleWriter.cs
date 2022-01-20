using UI.Abstractions;
using System;

namespace UI.Implementations
{
    public class ConsoleWriter : IOutput<string>
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
