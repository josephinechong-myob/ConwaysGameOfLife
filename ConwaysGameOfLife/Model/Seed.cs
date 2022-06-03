namespace ConwaysGameOfLife.Model
{
    public class Seed
    {
        public readonly int SeedDimensions;
        public readonly Cell[,] SeedGrid;

        public Seed(int seedDimensions, Cell[,] seedGrid)
        {
            SeedDimensions = seedDimensions;
            SeedGrid = seedGrid;
        }
    }
}