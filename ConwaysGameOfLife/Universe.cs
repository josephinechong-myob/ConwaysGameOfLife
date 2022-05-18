namespace ConwaysGameOfLife
{
    public class Universe
    {
        public IGameConsole UniverseGameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }

        public Universe(IGameConsole universeGameConsole, Seed seed)
        {
            UniverseGameConsole = universeGameConsole;
            UniverseGrid = seed.SeedGrid; // preset with user seed settings
            //UniverseGrid = new Cell[seed.SeedDimensions, seed.SeedDimensions];
            //UniverseGrid = seed.InitalGrid//new Cell[seed.SeedDimensions, seed.SeedDimensions];
        }
        public void CreateUniverse()
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
        
        public void DisplayUniverse()
        {
            var displayString = "";
            var width = UniverseGrid.GetLength(0);
            var height = UniverseGrid.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    UniverseGameConsole.ForegroundColor(UniverseGrid[i, j].Colour);
                    UniverseGameConsole.Write(UniverseGrid[i, j].Symbol);
                }
                UniverseGameConsole.Write("\n");
            }
        }
    }
}

// public IConsole SeedConsole;
// public int SeedDimensions;
// public string Content { get; set; }
// public Cell[,] UniverseGrid { get; set; } 
//
// public Universe(IConsole seedConsole, int seedDimensions)
// {
//     SeedDimensions = seedDimensions;
//     SeedConsole = seedConsole;
//     UniverseGrid = new Cell[SeedDimensions, SeedDimensions];
// }
        
//var cellsState = new State[seedUniverseDimensions, seedUniverseDimensions];


/*public void CreateUniverse(State[,] userSeedState) //
        {
            var width = UniverseGrid.GetUpperBound(0) + 1;
            var height = UniverseGrid.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    UniverseGrid[x, y] = new Cell(new Coordinate(x, y), userSeedState[x,y]);
                }
            }
        }*/
        
/*public void CreateInitialUniverse()
       {
           var width = UniverseGrid.GetUpperBound(0) + 1;
           var height = UniverseGrid.GetUpperBound(1) + 1;
           
           for (int x = 0; x < width; x++)
           {
               for (int y = 0; y < height; y++)
               {
                   UniverseGrid[x, y] = new Cell(new Coordinate(x, y), State.Dead);
               }
           }
       }
       
       public void CreateUniverse()
       {
           var width = UniverseGrid.GetUpperBound(0) + 1;
           var height = UniverseGrid.GetUpperBound(1) + 1;
           
           for (int x = 0; x < width; x++)
           {
               for (int y = 0; y < height; y++)
               {
                   UniverseGrid[x, y] = new Cell(new Coordinate(x, y), UniverseGrid[x,y].State);
               }
           }
       }*/
       
//public string Content { get; set; }
        
/*public Universe(IGameConsole universeGameConsole, Seed seed)
{
    UniverseGameConsole = universeGameConsole;
    UniverseGrid = new Cell[seed.SeedDimensions, seed.SeedDimensions];
    /*var seedDimensions = new Seed(universeGameConsole).SeedDimensions; //not sure if this is something I need to pass through
    UniverseGrid = new Cell[seedDimensions, seedDimensions];#1#
    //UniverseGrid = new Seed(seedConsole).GetSeedCellState();
}*/