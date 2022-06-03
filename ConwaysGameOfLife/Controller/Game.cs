using System.Threading;
using ConwaysGameOfLife.Model;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Controller
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
            var input = " ";
            var count = 0;

            while (InvalidEntry(input))
            {
                input = GetUserInput(Constants.Welcome, count);
                
                if (input == Constants.Option1)
                {
                    Play();
                }
                else if (input == Constants.Option2)
                {
                    Demo();
                }
                else
                {
                    _gameConsole.WriteLine(Constants.Terminal, Constants.InvalidEntry);
                    count++;
                }
            }
        }
        
        private bool InvalidEntry(string input)
        {
            return input != Constants.Option1 && input != Constants.Option2;
        }
        
        private string GetUserInput(string greeting, int count)
        {
            if (greeting == Constants.Welcome)
            {
                if (count == 0)
                {
                    _gameConsole.WriteLine(Constants.Green, Constants.Title);
                    _gameConsole.WriteLine(Constants.Terminal, Constants.WelcomeLine);
                }
            }
            else
            {
                _gameConsole.WriteLine(Constants.Terminal, greeting);
            }
            return _gameConsole.ReadLine();
        }
        
        private void Run(Universe universe)
        {
            while (!_gameConsole.KeyAvailable() && !universe.AllCellsAreDead)             
            {                                                                      
                _gameConsole.Clear();                                                   
                universe.UpdateUniverse(universe);                                 
                universe.DisplayUniverse(universe.UniverseGrid);                   
                Thread.Sleep(550);                                                 
            }
        }

        private void Play()                                                          
        {                                                                          
            SeedCreator seedCreator = new SeedCreator(_gameConsole);               
            seedCreator.MakeSeed();                                                
            var universe = new Universe(_gameConsole, seedCreator.GetSeed());
            Run(universe);
        }
        
        private void RunDemo(int seedDimensions, Cell[,] seedGrid)                                                  
        {
            var seed = new Seed(seedDimensions, seedGrid);                     
            var universe = new Universe(_gameConsole, seed);
            _gameConsole.WriteLine(Constants.Terminal, Constants.Demo);
            Run(universe);
        }

        private void Demo()
        {
            var input = " ";
            var count = 0;
            var demo = new Demo();
            while (InvalidEntry(input))
            {
                input = GetUserInput(Constants.SelectDemo, count);
                        
                if (input == Constants.Option1)
                {
                    RunDemo(30, demo.Seed30Grid);
                    
                }
                else if (input == Constants.Option2)
                {
                    RunDemo(40, demo.Seed40Grid);
                }
                else
                {
                    _gameConsole.WriteLine(Constants.Terminal, Constants.InvalidEntry);
                    count++;
                }
            }
        }
    }
}