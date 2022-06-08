using ConwaysGameOfLife.Console;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        public Cell[,] UniverseGrid { get; }
        public readonly int UniverseDimensions;
        public bool AllCellsAreDead;
        private readonly IGameConsole _gameConsole;
        private int Generation { get; set; }

        public Universe(IGameConsole gameConsole, Seed.Seed seed)
        {
            _gameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
            UniverseDimensions = seed.SeedDimensions;
        }
        
        public void UpdateUniverse(Universe universe)
        {
            universe.Generation++;

            foreach (var cell in universe.UniverseGrid)
            {
                var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
                neighbour.SetOrientation(cell);
                var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
                cell.State = StateLaws.GetNextState(cell.State, actualNumberOfLiveNeighbours);
            }
            
            CheckIfAllCellsAreDead(universe.UniverseGrid);
        }
        
        public void DisplayUniverse(Cell[,] universe)
        {
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int row = 0; row < width; row++)
            {
                for (int column = 0; column < height; column++)
                {
                    _gameConsole.Write(universe[row, column].GetColour(), universe[row, column].GetSymbol());
                }
                _gameConsole.Write(Constants.Terminal, Constants.NewLine);
            }
        }
        
        private void CheckIfAllCellsAreDead(Cell[,] universeGrid)
        {
            var count = 0;

            foreach (var cell in universeGrid)
            {
                if (cell.State == State.Dead)
                {
                    count++;
                }
            }

            AllCellsAreDead = count == universeGrid.Length;
            if (AllCellsAreDead)
            {
                _gameConsole.WriteLine(Constants.Terminal, Constants.DeadUniverse);
            }
        }
    }
}     