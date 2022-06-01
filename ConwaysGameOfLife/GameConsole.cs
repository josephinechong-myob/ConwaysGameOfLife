using System;

namespace ConwaysGameOfLife
{
    public class GameConsole : IGameConsole
    {
        public void Clear()
        {
            Console.Clear();
        }
        //on the unit level no value for testing implmentation of some of the console commands?
        
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

        public void FancyFont()
        {
            var title = @"
WELCOME to

 ▄████▄   ▒█████   ███▄    █  █     █░ ▄▄▄     ▓██   ██▓  ██████ 
▒██▀ ▀█  ▒██▒  ██▒ ██ ▀█   █ ▓█░ █ ░█░▒████▄    ▒██  ██▒▒██    ▒ 
▒▓█    ▄ ▒██░  ██▒▓██  ▀█ ██▒▒█░ █ ░█ ▒██  ▀█▄   ▒██ ██░░ ▓██▄   
▒▓▓▄ ▄██▒▒██   ██░▓██▒  ▐▌██▒░█░ █ ░█ ░██▄▄▄▄██  ░ ▐██▓░  ▒   ██▒
▒ ▓███▀ ░░ ████▓▒░▒██░   ▓██░░░██▒██▓  ▓█   ▓██▒ ░ ██▒▓░▒██████▒▒
░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░ ▓░▒ ▒   ▒▒   ▓▒█░  ██▒▒▒ ▒ ▒▓▒ ▒ ░
  ░  ▒     ░ ▒ ▒░ ░ ░░   ░ ▒░  ▒ ░ ░    ▒   ▒▒ ░▓██ ░▒░ ░ ░▒  ░ ░
░        ░ ░ ░ ▒     ░   ░ ░   ░   ░    ░   ▒   ▒ ▒ ░░  ░  ░  ░  
░ ░          ░ ░           ░     ░          ░  ░░ ░           ░  
░                                               ░ ░              
     
  ______                                            ______    ______         __        __   ______           
 /      \                                          /      \  /      \       |  \      |  \ /      \          
|  $$$$$$\  ______   ______ ____    ______        |  $$$$$$\|  $$$$$$\      | $$       \$$|  $$$$$$\ ______  
| $$ __\$$ |      \ |      \    \  /      \       | $$  | $$| $$_  \$$      | $$      |  \| $$_  \$$/      \ 
| $$|    \  \$$$$$$\| $$$$$$\$$$$\|  $$$$$$\      | $$  | $$| $$ \          | $$      | $$| $$ \   |  $$$$$$\
| $$ \$$$$ /      $$| $$ | $$ | $$| $$    $$      | $$  | $$| $$$$          | $$      | $$| $$$$   | $$    $$
| $$__| $$|  $$$$$$$| $$ | $$ | $$| $$$$$$$$      | $$__/ $$| $$            | $$_____ | $$| $$     | $$$$$$$$
 \$$    $$ \$$    $$| $$ | $$ | $$ \$$     \       \$$    $$| $$            | $$     \| $$| $$      \$$     \
  \$$$$$$   \$$$$$$$ \$$  \$$  \$$  \$$$$$$$        \$$$$$$  \$$             \$$$$$$$$ \$$ \$$       \$$$$$$$                                                                                                                                                                                                           
";
            Console.Write(title);
        }
    }
}