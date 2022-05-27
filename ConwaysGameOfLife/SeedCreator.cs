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
                _gameConsole.ForegroundColor(Constants.Terminal);
                _gameConsole.WriteLine(Constants.RequestUniverseGrid);
                var seed = _gameConsole.ReadLine();
                validNumber = int.TryParse(seed, out _seedDimensions);
            }

            _seedGrid = new Cell[_seedDimensions, _seedDimensions];
        }

        private void CreateSeedUniverse()
        {
            var width = _seedGrid.GetUpperBound(0) + Constants.ZeroIndexAdjustmentValue;
            var height = _seedGrid.GetUpperBound(1) + Constants.ZeroIndexAdjustmentValue;

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
            CreateSeedUniverse();
            PrintSeedUniverseForUserSelection(_seedGrid, _seedGrid[column, row]);
            UserSelection(column, row, _seedGrid);
        }
        
        private void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
            Console.Clear();
            int cellCount = 0;
            _gameConsole.ForegroundColor(Constants.Terminal);
            _gameConsole.WriteLine(Constants.UniverseGridInstructions);
            
            foreach (Cell cell in universe)
            {
                if (cell == selectedCell)
                {
                    _gameConsole.ForegroundColor(Constants.Cursor);
                }
                else
                {
                    if (cell.State == State.Alive)
                    {
                        _gameConsole.ForegroundColor(Constants.Alive);
                    }
                    else if (cell.State == State.Dead)
                    {
                        _gameConsole.ForegroundColor(Constants.Dead);
                    }
                    else
                    {
                        _gameConsole.ForegroundColor(ConsoleColor.White);
                    }
                }
                _gameConsole.Write(Constants.SquareCell);

                cellCount++;
                
                if (cellCount % _seedDimensions == 0)
                {
                    _gameConsole.Write("\n");
                }
            }
        }
        
        private void UserSelection(int column, int row, Cell[,] grid)
        {
            ConsoleKey keyInfo;
            
            do
            {
                keyInfo = _gameConsole.ReadKey();

                switch (keyInfo)
                {
                    case ConsoleKey.DownArrow:
                        column = column + Constants.ZeroIndexAdjustmentValue < _seedDimensions ? column + 1 : 0;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.UpArrow:
                        column = column - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn ? column - 1 : _seedDimensions - 1;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.RightArrow:
                        row = row + Constants.ZeroIndexAdjustmentValue < _seedDimensions ? row + 1 : 0;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.LeftArrow:
                        row = row - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn ? row - 1 : _seedDimensions - 1;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.Enter:
                        grid[column, row].State = grid[column, row].State == State.Alive ? State.Dead : State.Alive;
                        break;
                }
            } while (keyInfo != ConsoleKey.X);
        }

        /*private void UserSelection(int column, int row, Cell[,] grid)
        {
            ConsoleKey keyInfo;
            
            do
            {
                keyInfo = _gameConsole.ReadKey();

                if (keyInfo == ConsoleKey.DownArrow)
                {
                    if (column + Constants.ZeroIndexAdjustmentValue < _seedDimensions)
                    {
                        column++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                    else
                    {
                        column = 0;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]); 
                    }
                }

                if (keyInfo == ConsoleKey.UpArrow)
                {
                    if (column - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn)
                    {
                        column--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                    else
                    {
                        column = _seedDimensions - 1;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.RightArrow)
                {
                    if (row + Constants.ZeroIndexAdjustmentValue < _seedDimensions)
                    {
                        row++;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                    else
                    {
                        row = 0;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.LeftArrow)
                {
                    if (row - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn)
                    {
                        row--;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                    else
                    {
                        row = _seedDimensions - 1;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                    }
                }

                if (keyInfo == ConsoleKey.Enter)
                {
                    grid[column, row].State = grid[column, row].State == State.Alive ? State.Dead : State.Alive;
                }
            } while (keyInfo != ConsoleKey.X);
        }*/
    }
}