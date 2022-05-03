using System;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        public IConsole SeedConsole;
        public int SeedDimensions;
        public string Content { get; set; }
        public Cell[,] UniverseGrid { get; set; } 

        public Universe(IConsole seedConsole, int seedDimensions)
        {
            SeedDimensions = seedDimensions;
            SeedConsole = seedConsole;
            UniverseGrid = new Cell[SeedDimensions, SeedDimensions];
        }
        
        public void CreateUniverse(State[,] userSeedState)
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
                    SeedConsole.ForegroundColor(UniverseGrid[i, j].Colour);
                    SeedConsole.Write(UniverseGrid[i, j].Symbol);
                }
                SeedConsole.Write("\n");
            }
        }

        private void UpdateUniverse()
        {
            
        }
    }
}