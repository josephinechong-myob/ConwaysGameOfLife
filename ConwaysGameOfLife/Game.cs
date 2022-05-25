using System;
using ConwaysGameOfLife.Orientations;

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
            //while loop and check user input of x to exit
            universe.UpdateUniverse(universe);
            universe.UpdateUniverse(universe);
            universe.UpdateUniverse(universe);
        }
        
    }
}