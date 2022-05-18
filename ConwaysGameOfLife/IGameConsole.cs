using System;

namespace ConwaysGameOfLife
{
    public interface IGameConsole
    {
        public void ForegroundColor(ConsoleColor consoleColor);
        public void Write(string write);
        public void WriteLine(string writeLine);
        public string ReadLine();
        public ConsoleKey ReadKey();
    }
}