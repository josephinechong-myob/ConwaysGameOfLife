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

        /*public void Run(Universe universe)
        {
            //seedCreator.MakeSeed();  
            //console.ReadKey();
            //var seed = seedCreator.GetSeed();
            
            
            //update universe(update state for every cell) + update generation + display universe
            //put in a while loop unless user enters x to exit
            UpdateUniverse(universe);
        }*/

        public void UpdateUniverse(Universe universe)
        {
            Console.Clear();
            universe.Generation++;

            var width = universe.UniverseGrid.GetLength(0);
            var height = universe.UniverseGrid.GetLength(1);
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cell = universe.UniverseGrid[x, y];
                    var neighbour = new Neighbour(cell, universe._universeDimensions);
                    universe.SetOrientation(cell);
                    //var actualNumberOfLiveNeighbours = universe.GetLiveNeighbours(cell);
                    var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe._universeDimensions);
                    
                    universe.UniverseGrid[x, y].State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
                    cell.UpdateColour(universe.UniverseGrid[x, y].State);

                }
            }

            /*for (int x = 0; x < width; x++)//row
            {
                for (int y = 0; y < height; y++)//column
                {
                    var cell = universe.UniverseGrid[x, y];
                    universe.SetOrientation(cell);
                    var actualNumberOfLiveNeighbours = universe.GetLiveNeighbours(cell);
                    universe.UniverseGrid[x, y].State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
                    break;
                }
            }*/
            
            universe.DisplayUniverse(universe.UniverseGrid);
        }
    }
}