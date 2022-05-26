using System;

namespace ConwaysGameOfLife
{
    public class SeedCreator
    {
        private readonly IGameConsole _gameConsole;
        private int _seedDimensions;
        private Cell[,] _seedGrid;

        public SeedCreator(IGameConsole gameConsole)
        {
            _gameConsole = gameConsole;
        }
        public Seed GetSeed()
        {
            return new Seed(_seedDimensions, _seedGrid);
        }

        public void MakeSeed()
        {
            SetSeedDimensions();
            SetSeedCellState();
        }

        public void SetSeedDimensions()
        {
            var validNumber = false;
            
            while (!validNumber)
            {
                _gameConsole.WriteLine("How big would you like the universe grid size to be? Please enter a number (i.e. 3)");
                var seed = _gameConsole.ReadLine();
                validNumber = int.TryParse(seed, out _seedDimensions);
            }

            _seedGrid = new Cell[_seedDimensions, _seedDimensions];
        }

        private void CreateUniverse()
        {
            var width = _seedGrid.GetUpperBound(0) + 1;
            var height = _seedGrid.GetUpperBound(1) + 1;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _seedGrid[x, y] = new Cell(new Coordinate(x, y), State.Dead);
                }
            }
        }

         public void SetSeedCellState()
        {
            var column = 0;
            var row = 0;
            CreateUniverse();
            PrintSeedUniverseForUserSelection(_seedGrid, _seedGrid[column, row]);
            UserSelection(column, row, _seedGrid);
        }
        
        private void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
            Console.Clear();
            int cellCount = 0;
            _gameConsole.WriteLine($"Select cells you want ALIVE with keyboard arrows\nPress 'Enter' to select cell\nPress 'X' to exit");
            
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
                
                if (cellCount % _seedDimensions == 0)
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
                keyInfo = _gameConsole.ReadKey();

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
                    }
                    else
                    {
                        grid[column, row].State = State.Alive;
                    }
                }
            } while (keyInfo != ConsoleKey.X);
        }
    }
}