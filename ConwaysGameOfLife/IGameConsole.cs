using System;

namespace ConwaysGameOfLife
{
    public interface IGameConsole
    {
        public void Clear();
        public void ForegroundColor(ConsoleColor consoleColor);
        public bool KeyAvailable();
        public ConsoleKey ReadKey();
        public string ReadLine();
        public void Write(string write);
        public void WriteLine(string writeLine);
        public void FancyFont();
    }
}