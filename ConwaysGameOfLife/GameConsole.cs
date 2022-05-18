using System;

namespace ConwaysGameOfLife
{
    public class GameConsole : IGameConsole
    {
        public void ForegroundColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        public void Write(string write)
        {
            Console.Write(write);
        }
        
        public void WriteLine(string writeLine)
        {
            Console.WriteLine(writeLine);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        
        public ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }
        //print cell function (output for console)
    }
}