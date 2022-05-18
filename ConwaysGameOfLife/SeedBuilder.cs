using System;

namespace ConwaysGameOfLife
{
    public class SeedBuilder
    {
        private IGameConsole GameConsole;
        private int SeedDimensions;
        private Cell[,] SeedGrid;
        
        public SeedBuilder(IGameConsole gameConsole)
        {
            GameConsole = gameConsole;
        }
        public Seed GetSeed()
        {
            return new Seed(SeedDimensions, SeedGrid);
        }

        public void SetSeedDimensions()
        {
            var validNumber = false;
            
            while (!validNumber)
            {
                GameConsole.WriteLine("How big would you like the universe grid size to be? Please enter a number (i.e. 3)");
                var seed = GameConsole.ReadLine();
                validNumber = int.TryParse(seed, out SeedDimensions);
            }

            SeedGrid = new Cell[SeedDimensions, SeedDimensions];
        }
        
        public void CreateUniverse()
        {
            var width = SeedGrid.GetUpperBound(0) + 1;
            var height = SeedGrid.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    SeedGrid[x, y] = new Cell(new Coordinate(x, y), State.Dead);
                }
            }
        }

         public void SetSeedCellState()
        {
            int column = 0;
            int row = 0;
            CreateUniverse();
            PrintSeedUniverseForUserSelection(SeedGrid, SeedGrid[column, row]);
            UserSelection(column, row, SeedGrid);
        }
        
        private void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
            Console.Clear();
            int cellCount = 0;
            GameConsole.WriteLine($"Select cells you want ALIVE with keyboard arrows\nPress 'Enter' to select cell\nPress 'X' to exit");
            
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
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write(" \u25fc ");
                
                cellCount++;
                
                if (cellCount % SeedDimensions == 0)
                {
                    Console.Write("\n");
                }
            }
        }

        private void UserSelection(int column, int row, Cell[,] grid)
        {
            ConsoleKey keyInfo;
            do
            {
                keyInfo = GameConsole.ReadKey();

                if (keyInfo == ConsoleKey.DownArrow)
                {
                    if (column + 1 < grid.Length)
                    {
                        column++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.UpArrow)
                {
                    if (column - 1 >= 0)
                    {
                        column--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.RightArrow)
                {
                    if (row + 1 < grid.Length)
                    {
                        row++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.LeftArrow)
                {
                    if (row - 1 >= 0)
                    {
                        row--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.Enter)
                {
                    if (grid[column, row].State == State.Alive)
                    {
                        grid[column, row].State = State.Dead;
                       // SeedCellState[column, row] = State.Dead; 
                    }
                    else
                    {
                        grid[column, row].State = State.Alive;
                       // SeedCellState[column, row] = State.Alive;
                    }
                }
            } while (keyInfo != ConsoleKey.X);
            
        }
    }
}