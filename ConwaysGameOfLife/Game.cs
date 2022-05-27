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

        public void Options()
        {
            _gameConsole.ForegroundColor(Constants.Terminal);
            _gameConsole.WriteLine(Constants.Welcome);
            var input = _gameConsole.ReadLine();
            
            if (input == Constants.Option1)
            {
                Run(); 
            }
            else if (input == Constants.Option2)
            {
                Demo();
            }
        }

        public void Demo()
        {
            _gameConsole.WriteLine("This is the demo");

            var seedDimensions = 30;
            /*var seedGrid = 

            var seed = new Seed(seedDimensions, );*/
        }
        
        public void Run()
        {
            SeedCreator seedCreator = new SeedCreator(_gameConsole);
            seedCreator.MakeSeed();
            var universe = new Universe(_gameConsole, seedCreator.GetSeed());
            
            while (!Console.KeyAvailable && !universe.AllCellsAreDead)
            {
                Console.Clear();
                universe.UpdateUniverse(universe);
                universe.DisplayUniverse(universe.UniverseGrid);
                Thread.Sleep(800);
            }
        }
    }
}