using System;

namespace ConwaysGameOfLife.View
{
    public interface IGameConsole
    {
        public void Clear();
        public void ForegroundColor(ConsoleColor consoleColor);
        public bool KeyAvailable();
        public ConsoleKey ReadKey();
        public string ReadLine();
        public void WriteLine(ConsoleColor colour, string writeLine);
        public void Write(ConsoleColor colour, string write);
    }
}