using System;
using ConwaysGameOfLife.Orientations;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private readonly IGameConsole _gameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }
        public readonly int UniverseDimensions;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            _gameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
            UniverseDimensions = seed.SeedDimensions;
        }
        
         public void UpdateUniverse(Universe universe)
        {
            Console.Clear();
            universe.Generation++;

            foreach (var cell in universe.UniverseGrid)
            {
                var neighbour = new Neighbour(cell, universe.UniverseDimensions);
                neighbour.SetOrientation(cell);
                var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
                cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
                //cell.UpdateColour(cell.State);
            }
            
            universe.DisplayUniverse(universe.UniverseGrid);

            //WORKING
            /*var width = universe.UniverseGrid.GetLength(0);
            var height = universe.UniverseGrid.GetLength(1);
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cell = universe.UniverseGrid[x, y];
                    var neighbour = new Neighbour(cell, universe.UniverseDimensions);
                    neighbour.SetOrientation(cell);
                    var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
                    universe.UniverseGrid[x, y].State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
                    cell.UpdateColour(universe.UniverseGrid[x, y].State);

                }
            }*/
            
           
            
            
        }
        
        public void DisplayUniverse(Cell[,] universe)
        {
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int row = 0; row < width; row++)
            {
                for (int column = 0; column < height; column++)
                {
                    _gameConsole.ForegroundColor(universe[row, column].Colour);
                    _gameConsole.Write(universe[row, column].Symbol);
                }
                _gameConsole.Write("\n");
            }
        }
    }
}     