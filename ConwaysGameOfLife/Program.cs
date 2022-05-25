namespace ConwaysGameOfLife
{
    static class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var game = new Game(console);
            SeedCreator seedCreator = new SeedCreator(console);
            seedCreator.MakeSeed();
            var universe = new Universe(console, seedCreator.GetSeed());
            game.UpdateUniverse(universe);
        }
    }
}