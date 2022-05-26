using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    public class Game
    {
        private readonly IGameConsole _gameConsole;
        
        public Game(IGameConsole gameConsole)
        {
            _gameConsole = gameConsole;
        }
        
       

        public void Run()
        {
            SeedCreator seedCreator = new SeedCreator(_gameConsole);
            seedCreator.MakeSeed();
            var universe = new Universe(_gameConsole, seedCreator.GetSeed());
            
            ConsoleKey keyInfo;
            //keyInfo = _gameConsole.ReadKey();

            do
            {
                Console.Clear();
                universe.UpdateUniverse(universe);
                universe.DisplayUniverse(universe.UniverseGrid);
                //keyInfo = _gameConsole.ReadKey();
                Thread.Sleep(800);
                /*if (keyInfo == ConsoleKey.X)
                {
                    break;
                }*/
            }
            while (!universe.AllCellsDead);
            //} while (keyInfo != ConsoleKey.X);
        }
    }
}