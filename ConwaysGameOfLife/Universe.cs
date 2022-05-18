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
            var displayString = "";
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //GameConsole.ForegroundColor(UniverseGrid[i, j].Colour);
                    if (universe[i, j].State == State.Alive)
                    {
                        GameConsole.ForegroundColor(Constants.Alive);
                    }
                    else if (universe[i, j].State == State.Dead)
                    {
                        GameConsole.ForegroundColor(Constants.Dead);
                    }
                    GameConsole.Write(universe[i, j].Symbol);
                }
                GameConsole.Write("\n");
            }
        }
        
        /*public void DisplayUniverse()
        {
            var displayString = "";
            var width = UniverseGrid.GetLength(0);
            var height = UniverseGrid.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //GameConsole.ForegroundColor(UniverseGrid[i, j].Colour);
                    if (UniverseGrid[i, j].State == State.Alive)
                    {
                        GameConsole.ForegroundColor(Constants.Alive);
                    }
                    else if (UniverseGrid[i, j].State == State.Dead)
                    {
                        GameConsole.ForegroundColor(Constants.Dead);
                    }
                    GameConsole.Write(UniverseGrid[i, j].Symbol);
                }
                GameConsole.Write("\n");
            }
        }*/
    }
}           