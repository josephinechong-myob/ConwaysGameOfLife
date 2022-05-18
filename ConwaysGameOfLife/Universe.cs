namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IGameConsole GameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
        }
        public void CreateUniverse() //is this still needed?
        {
            var width = UniverseGrid.GetUpperBound(0) + 1;
            var height = UniverseGrid.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var state = Generation == 0 ? State.Dead : UniverseGrid[x, y].State;
                    UniverseGrid[x, y] = new Cell(new Coordinate(x, y), state);
                }
            }
        }
        
        public void DisplayUniverse(Cell[,] universe)
        {
            //var displayString = "";
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameConsole.ForegroundColor(universe[i, j].Colour);
                    GameConsole.Write(universe[i, j].Symbol);
                }
                GameConsole.Write("\n");
            }
        }
    }
}           