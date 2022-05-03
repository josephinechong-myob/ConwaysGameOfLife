using System;

namespace ConwaysGameOfLife
{
    public class SeedConsole : IConsole
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
        //print cell function (output for console)
    }
}