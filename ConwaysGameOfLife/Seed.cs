using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    public class Seed
    {
        public int SeedDimensions;
        public State[,] SeedInitialState;
        public IConsole SeedConsole;
       // public static Option[,] Options;
        
        public Seed(IConsole console)
        {
            SeedConsole = console;
            SeedDimensions = GetSeedDimensions();
            SeedInitialState = GetSeedInitialState();
           // Options = options;
            //SeedInitialState = new State[SeedDimensions,SeedDimensions]
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
        
        static void WriteMenu(Cell[,] universe, Cell selectedCell, int seedDimension)
        {
            Console.Clear();
            int cellCount = 0;
            foreach (Cell cell in universe)
            {
                if (cell == selectedCell)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.White;
                    if (cell.State == State.Alive)
                    {
                        Console.ForegroundColor = Constants.Alive;
                    }
                    else if (cell.State == State.Dead)
                    {
                        Console.ForegroundColor = Constants.Dead;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                //Console.Write(cell.State);
                Console.Write(" \u25fc ");
                cellCount++;
                if (cellCount % seedDimension == 0)
                {
                    Console.Write(" \n ");
                }
            }
        }

        public State[,] GetSeedInitialState()
        {
            SeedInitialState = new State[SeedDimensions, SeedDimensions];
            SeedConsole.WriteLine("Select the cells you would like alive.");
            var universe = new Universe(SeedConsole, SeedDimensions);
            var grid = universe.UniverseGrid;
            universe.CreateInitialUniverse();
            universe.DisplayUniverse();
            int column = 0;
            int row = 0;
            WriteMenu(grid, grid[column, row], SeedDimensions);
            
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (column + 1 < grid.Length)
                    {
                        column++;
                        WriteMenu(grid, grid[column, row], SeedDimensions);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (column - 1 >= 0)
                    {
                        column--;
                        WriteMenu(grid, grid[column, row], SeedDimensions);
                    }
                }

                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (row + 1 < grid.Length)
                    {
                        row++;
                        WriteMenu(grid, grid[column, row], SeedDimensions);
                    }
                }

                if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (row - 1 >= 0)
                    {
                        row--;
                        WriteMenu(grid, grid[column, row], SeedDimensions);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    grid[column, row].State = State.Alive;
                    grid[column, row].Colour = ConsoleColor.Cyan;
                    SeedInitialState[column, row] = State.Alive;
                    column = 0;
                }
            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
            return SeedInitialState;
        }
        
        /*static void UpdateSelectedCellStateForSeed(string message)
        {
            // Console.Clear();
            // Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(3000);
            WriteMenu(Options, Options[0,0]);
        }
            
      */
        
    }
}