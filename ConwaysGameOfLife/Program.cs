namespace ConwaysGameOfLife
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var console = new GameConsole();
            var game = new Game(console);
            game.Run();
        }
    }
}