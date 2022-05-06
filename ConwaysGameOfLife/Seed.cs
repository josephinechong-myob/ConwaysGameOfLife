using System;

namespace ConwaysGameOfLife
{
    public class Seed
    {
        public int SeedDimensions;
        public State[,] SeedCellState;
        public IConsole SeedConsole;

        public Seed(IConsole console)
        {
            SeedConsole = console;
            SeedDimensions = GetSeedDimensions();
            SeedCellState = GetSeedCellState();
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
        
        public void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
            Console.Clear();
            int cellCount = 0;
            SeedConsole.WriteLine("Select the cells you would like alive.");
            foreach (Cell cell in universe)
            {
                if (cell == selectedCell)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    if (cell.State == State.Alive)
                    {
                        Console.ForegroundColor = Constants.Alive;
                    }
                    else if (cell.State == State.Dead)
                    {
                        Console.ForegroundColor = Constants.Dead;
                    }
                }
                Console.Write(" \u25fc ");
                
                cellCount++;
                
                if (cellCount % SeedDimensions == 0)
                {
                    Console.Write(" \n ");
                }
            }
        }

        public State[,] GetSeedCellState()
        {
            SeedCellState = new State[SeedDimensions, SeedDimensions];
            var universe = new Universe(SeedConsole, SeedDimensions);
            var grid = universe.UniverseGrid;
            universe.CreateInitialUniverse();
            int column = 0;
            int row = 0;
            PrintSeedUniverseForUserSelection(grid, grid[column, row]);
            
            ConsoleKeyInfo keyinfo;
            do
            {
                //keyinfo = Console.ReadKey();
                keyinfo = SeedConsole.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (column + 1 < grid.Length)
                    {
                        column++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (column - 1 >= 0)
                    {
                        column--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (row + 1 < grid.Length)
                    {
                        row++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (row - 1 >= 0)
                    {
                        row--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    if (grid[column, row].State == State.Alive)
                    {
                        grid[column, row].State = State.Dead;
                        SeedCellState[column, row] = State.Dead;
                    }
                    else
                    {
                        grid[column, row].State = State.Alive;
                        SeedCellState[column, row] = State.Alive;
                    }
                }
            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
            return SeedCellState;
        }
    }
}