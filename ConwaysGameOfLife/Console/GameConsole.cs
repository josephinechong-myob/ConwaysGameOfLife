using System;

namespace ConwaysGameOfLife.Console
{
    public class GameConsole : IGameConsole
    {
        public void Clear()
        {
            System.Console.Clear();
        }
        
        public void ForegroundColor(ConsoleColor consoleColor)
        {
            System.Console.ForegroundColor = consoleColor;
        }
        
        public bool KeyAvailable()
        {
            return System.Console.KeyAvailable;
        }
        
        public ConsoleKey ReadKey()
        {
            return System.Console.ReadKey().Key;
        }
        
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void WriteLine(ConsoleColor colour, string writeLine)
        {
            System.Console.ForegroundColor = colour;
            System.Console.WriteLine(writeLine);
        }
        
        public void Write(ConsoleColor colour, string write)
        {
            System.Console.ForegroundColor = colour;
            System.Console.Write(write);
        }
    }
}