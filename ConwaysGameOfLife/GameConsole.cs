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

        public void WriteLine(ConsoleColor colour, string writeLine)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(writeLine);
        }
        
        public void Write(ConsoleColor colour, string write)
        {
            Console.ForegroundColor = colour;
            Console.Write(write);
        }
    }
}