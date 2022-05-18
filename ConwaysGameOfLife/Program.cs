namespace ConwaysGameOfLife
{
    static class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            SeedCreator seedCreator = new SeedCreator(console);
            seedCreator.MakeSeed();
            console.ReadKey();
        }
    }
}