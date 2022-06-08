using System;
using ConwaysGameOfLife.Console;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife.Seed
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

        private void SetSeedDimensions()
        {
            var validNumber = false;
            
            while (!validNumber)
            {
                _gameConsole.WriteLine(Constants.Terminal, Constants.RequestUniverseGrid);
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

        private void SetSeedCellState()
        {
            var column = Constants.FirstRowOrColumn;
            var row = Constants.FirstRowOrColumn;
            CreateSeedUniverse();
            PrintSeedUniverseForUserSelection(_seedGrid, _seedGrid[column, row]);
            UserSelection(column, row, _seedGrid);
        }
         
        private void PrintSeedUniverseForUserSelection(Cell[,] universe, Cell selectedCell)
        {
             _gameConsole.Clear();
             var cellCount = 0;
             _gameConsole.WriteLine(Constants.Terminal, Constants.UniverseGridInstructions);
            
             foreach (Cell cell in universe)
             {
                 var colour = cell == selectedCell ? Constants.Cursor : cell.State == State.Alive ? Constants.Alive : cell.State == State.Dead ? Constants.Dead : ConsoleColor.White;
                 _gameConsole.Write(colour, Constants.SquareCell);
                 cellCount++;

                 if (cellCount % _seedDimensions == 0)
                 {
                     _gameConsole.Write(Constants.Terminal, Constants.NewLine);
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
                        column = column + Constants.ZeroIndexAdjustmentValue < _seedDimensions ? column + Constants.ZeroIndexAdjustmentValue : Constants.FirstRowOrColumn;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.UpArrow:
                        column = column - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn ? column - Constants.ZeroIndexAdjustmentValue : _seedDimensions - Constants.ZeroIndexAdjustmentValue;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.RightArrow:
                        row = row + Constants.ZeroIndexAdjustmentValue < _seedDimensions ? row + Constants.ZeroIndexAdjustmentValue : Constants.FirstRowOrColumn;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.LeftArrow:
                        row = row - Constants.ZeroIndexAdjustmentValue >= Constants.FirstRowOrColumn ? row - Constants.ZeroIndexAdjustmentValue : _seedDimensions - Constants.ZeroIndexAdjustmentValue;
                        PrintSeedUniverseForUserSelection(grid, grid[column, row]);
                        break;
                    
                    case ConsoleKey.Enter:
                        grid[column, row].State = grid[column, row].State == State.Alive ? State.Dead : State.Alive;
                        break;
                }
            } while (keyInfo != ConsoleKey.X);
        }
    }
}