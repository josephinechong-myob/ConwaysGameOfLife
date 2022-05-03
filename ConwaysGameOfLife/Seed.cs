namespace ConwaysGameOfLife
{
    public class Seed
    {
        public int SeedDimensions;
        public string[,] SeedUniverseSettings;
        public IConsole SeedConsole;
        
        public Seed(IConsole console)
        {
            SeedConsole = console;
            SeedDimensions = GetSeedDimensions();
            //SeedUniverseSettings = new string[,] ;
        }
        
        public int GetSeedDimensions()
        {
            var validNumber = false;
            
            while (!validNumber)
            {
                SeedConsole.WriteLine("How big would you like the universe grid size to be? Please enter a number (i.e. 3)");
                var seed = SeedConsole.ReadLine();
                validNumber = int.TryParse(seed, out SeedDimensions);
            }
            return SeedDimensions;
        }
    }
}