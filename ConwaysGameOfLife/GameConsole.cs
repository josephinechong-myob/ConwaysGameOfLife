using System;

namespace ConwaysGameOfLife
{
    public class GameConsole : IGameConsole
    {
        public void Clear()
        {
            Console.Clear();
        }
        
        public void ForegroundColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }
        
        public bool KeyAvailable()
        {
            return Console.KeyAvailable;
        }
        
        public ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }
        
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string write)
        {
            Console.Write(write);
        }
        
        public void WriteLine(string writeLine)
        {
            Console.WriteLine(writeLine);
        }
    }
}