using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    public class Game
    {
        private readonly IGameConsole _gameConsole;
        
        public Game(IGameConsole gameConsole)
        {
            _gameConsole = gameConsole;
        }
        
        //To do:
        //1. refactoring (Wed COB)                                                                                       
        //2. file organisation for files                                                                                     
        //3. updating the class diagram                                                                                     
        //4. slide deck - Diagram, live Dem0, design patterns, any lessons learned, questions, possible strech goals (      

        public void Options()
        {
            _gameConsole.ForegroundColor(Constants.Terminal);
            _gameConsole.WriteLine(Constants.Welcome);
            var input = _gameConsole.ReadLine();
            
            if (input == Constants.Option1)
            {
                Run(); 
            }
            else if (input == Constants.Option2)
            {
                _gameConsole.ForegroundColor(Constants.Terminal); 
                _gameConsole.WriteLine($"Enter '1' - for grid size 30 demo\nEnter '2' - for grid size 40 demo");
                input = _gameConsole.ReadLine();
                if (input == Constants.Option1)
                {
                    Demo30(); 
                }
                else if (input == Constants.Option2)
                {
                    Demo40();
                }
            }
        }
        
        public void Run()                                                          
        {                                                                          
            SeedCreator seedCreator = new SeedCreator(_gameConsole);               
            seedCreator.MakeSeed();                                                
            var universe = new Universe(_gameConsole, seedCreator.GetSeed());      
                                                                            
            while (!Console.KeyAvailable && !universe.AllCellsAreDead)             
            {                                                                      
                Console.Clear();                                                   
                universe.UpdateUniverse(universe);                                 
                universe.DisplayUniverse(universe.UniverseGrid);                   
                Thread.Sleep(800);                                                 
            }                                                                      
        }

        private void Demo30()
        {
            var seedDimensions = 40;
            var demo = new Demo();
            var seedGrid = demo.Seed40Grid;
            var seed = new Seed(seedDimensions, seedGrid);
            var universe = new Universe(_gameConsole, seed);    
                                                                     
            while (!Console.KeyAvailable && !universe.AllCellsAreDead)           
            {                                                                    
                Console.Clear();                                                 
                universe.UpdateUniverse(universe);                               
                universe.DisplayUniverse(universe.UniverseGrid);                 
                Thread.Sleep(550);                                               
            }                                                                    
        }
        
        private void Demo40()                                                  
        {                                                                      
            var seedDimensions = 30;                                           
            var demo = new Demo();                                             
            var seedGrid = demo.Seed30Grid;                                    
            var seed = new Seed(seedDimensions, seedGrid);                     
            var universe = new Universe(_gameConsole, seed);                   
                                                                       
            while (!Console.KeyAvailable && !universe.AllCellsAreDead)         
            {                                                                  
                Console.Clear();                                               
                universe.UpdateUniverse(universe);                             
                universe.DisplayUniverse(universe.UniverseGrid);               
                Thread.Sleep(550);                                             
            }                                                                  
        }                                                                      
    }
}