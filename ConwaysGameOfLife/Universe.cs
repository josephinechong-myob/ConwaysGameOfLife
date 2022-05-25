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