namespace ConwaysGameOfLife
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var console = new GameConsole();
            var game = new Game(console);
            
            game.Options();
            
            //To do:
            //1. refactoring (Wed COB)                                                                                       
            //2. file organisation for files                                                                                     
            //3. updating the class diagram                                                                                     
            //4. slide deck - Diagram, live Dem0, design patterns, any lessons learned, questions, possible stretch goals 
        }
    }
}