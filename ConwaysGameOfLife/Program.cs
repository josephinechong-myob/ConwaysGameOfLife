namespace ConwaysGameOfLife
{
    class Program
        
    // 3) option need to be available when user is happy with their seed settings and wants to exit and start the program
    {
        static void Main(string[] args)
        {
            var console = new SeedConsole();
            var seed = new Seed(console);
            var dimensions = seed.SeedDimensions;
            var setSeed = seed.SeedCellState;
        }
    }
}