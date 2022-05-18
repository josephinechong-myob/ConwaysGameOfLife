using System;

namespace ConwaysGameOfLife
{
    public class Seed
    {
        private readonly IGameConsole _seedGameConsole;
        public int SeedDimensions;
        public Cell[,] SeedGrid;

        public Seed(IGameConsole gameConsole) //seed builder for console
        {
            _seedGameConsole = gameConsole;
        }

        //public Seed(int seedDimensions, Cell[,] seedGrid)
        public Seed(int seedDimensions, Cell[,] seedGrid)
        {
            //SeedDimensions = seedDimensions;
           // SeedGrid = seedGrid;
           // SeedGrid = new Cell[SeedDimensions, SeedDimensions];
           SeedDimensions = seedDimensions;
           SeedGrid = seedGrid;
        }

        /*public void SetSeedDimensions()
        {
            var validNumber = false;
            
            while (!validNumber)
            {
                _seedGameConsole.WriteLine("How big would you like the universe grid size to be? Please enter a number (i.e. 3)");
                var seed = _seedGameConsole.ReadLine();
                validNumber = int.TryParse(seed, out SeedDimensions);
            }
        }*/
        
        /*public void SetSeedCellState()
        {
            int column = 0;
            int row = 0;
            PrintSeedUniverseForUserSelection(SeedGrid, SeedGrid[column, row]);
            UserSelection(column, row, SeedGrid);
        }
        
        private void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
            Console.Clear();
            int cellCount = 0;
            _seedGameConsole.WriteLine($"Select cells you want ALIVE with keyboard arrows\nPress 'Enter' to select cell\nPress 'X' to exit");
            
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
                keyInfo = _seedGameConsole.ReadKey();

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

            _seedGameConsole.ReadKey(); 
        }*/
    }
}

/*
private readonly IGameConsole _seedGameConsole;
public int SeedDimensions;
//public Cell[,] SeedCellState; // delete this if I am updating the Cell state in Universe

public Seed(IGameConsole gameConsole)
{
    _seedGameConsole = gameConsole;
    //SeedDimensions = GetSeedDimensions();
    //SeedCellState = GetSeedCellState();
    //SeedInitialState = new State[SeedDimensions,SeedDimensions]
}

public void SetSeedDimensions()
{
    var validNumber = false;
            
    while (!validNumber)
    {
        _seedGameConsole.WriteLine("How big would you like the universe grid size to be? Please enter a number (i.e. 3)");
        var seed = _seedGameConsole.ReadLine();
        validNumber = int.TryParse(seed, out SeedDimensions);
    }
    // return SeedDimensions;
}
        
        
public void SetSeedCellState(Universe universe)
{
    int column = 0;
    int row = 0;
            
    //var universe = new Universe(_seedConsole, SeedDimensions);
    //var universe = new Universe(_seedGameConsole);
    var grid = universe.UniverseGrid;
    //universe.CreateInitialUniverse();
    universe.CreateUniverse();
    PrintSeedUniverseForUserSelection(grid, grid[column, row]);
    UserSelection(column, row, grid);
}
*/
