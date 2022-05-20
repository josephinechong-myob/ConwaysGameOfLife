using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IGameConsole GameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }
        private readonly int _universeDimensions;
        private int _liveNeighbours;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
            _universeDimensions = seed.SeedDimensions;
        }
        public void CreateUniverse() //is this still needed?
        {
            var width = UniverseGrid.GetUpperBound(0) + 1;
            var height = UniverseGrid.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var state = Generation == 0 ? State.Dead : UniverseGrid[x, y].State;
                    UniverseGrid[x, y] = new Cell(new Coordinate(x, y), state);
                }
            }
        }
        
        public void DisplayUniverse(Cell[,] universe)
        {
            //var displayString = "";
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameConsole.ForegroundColor(universe[i, j].Colour);
                    GameConsole.Write(universe[i, j].Symbol);
                }
                GameConsole.Write("\n");
            }
        }
        
        public void GetOrientation(Cell cell)
        {
            CheckIfCorner(cell);
            CheckIfSide(cell);
            cell.Orientation ??= Orientation.Middle;
        }

        public int GetLiveNeighbours(Cell cell)
        {
            if (cell.Orientation == Orientation.TopLeftCorner)
            {
                _liveNeighbours = GetLiveNeighboursOfTopLeftCornerCellPosition(cell.Coordinate);
            }
            else if (cell.Orientation == Orientation.TopRightCorner)
            {
                _liveNeighbours = GetLiveNeighboursOfTopRightCornerCellPosition(cell.Coordinate);
            }
            else if (cell.Orientation == Orientation.BottomLeftCorner)
            {
                _liveNeighbours = GetLiveNeighboursOfBottomLeftCornerCellPosition(cell.Coordinate);
            }

            return _liveNeighbours;
        }

        private int GetLiveNeighboursOfTopLeftCornerCellPosition(Coordinate coordinate)
        {
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[LastRowOrColumn(), LastRowOrColumn()].State, 
                UniverseGrid[LastRowOrColumn(), NextColumn(coordinate)].State, 
                UniverseGrid[NextRow(coordinate), LastRowOrColumn()].State, 
                UniverseGrid[NextRow(coordinate), NextColumn(coordinate)].State,
                UniverseGrid[LastRowOrColumn(), Constants.FirstRowOrColumn].State, 
                UniverseGrid[NextRow(coordinate), Constants.FirstRowOrColumn].State, 
                UniverseGrid[Constants.FirstRowOrColumn, LastRowOrColumn()].State,
                UniverseGrid[Constants.FirstRowOrColumn, NextColumn(coordinate)].State
            };

            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);

            return numberOfLiveNeighbours;
        }
        
        private int GetLiveNeighboursOfTopRightCornerCellPosition(Coordinate coordinate)
        {
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[Constants.FirstRowOrColumn, Constants.FirstRowOrColumn].State, 
                UniverseGrid[LastRowOrColumn(), LastRowOrColumn()].State, 
                UniverseGrid[LastRowOrColumn(), Constants.FirstRowOrColumn].State, 
                UniverseGrid[Constants.FirstRowOrColumn, PreviousColumn(coordinate)].State,
                UniverseGrid[NextRow(coordinate), PreviousColumn(coordinate)].State, 
                UniverseGrid[LastRowOrColumn(), PreviousColumn(coordinate)].State, 
                UniverseGrid[NextRow(coordinate), Constants.FirstRowOrColumn].State,
                UniverseGrid[NextRow(coordinate), LastRowOrColumn()].State
            };

            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);

            return numberOfLiveNeighbours;
        }
        
        private int GetLiveNeighboursOfBottomLeftCornerCellPosition(Coordinate coordinate)
        {
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[Constants.FirstRowOrColumn, Constants.FirstRowOrColumn].State, 
                UniverseGrid[LastRowOrColumn(), LastRowOrColumn()].State, 
                UniverseGrid[Constants.FirstRowOrColumn, LastRowOrColumn()].State, 
                UniverseGrid[LastRowOrColumn(), NextColumn(coordinate)].State,
                UniverseGrid[Constants.FirstRowOrColumn, NextColumn(coordinate)].State, 
                UniverseGrid[PreviousRow(coordinate), NextColumn(coordinate)].State, 
                UniverseGrid[PreviousRow(coordinate), Constants.FirstRowOrColumn].State,
                UniverseGrid[PreviousRow(coordinate), LastRowOrColumn()].State
            };

            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);

            return numberOfLiveNeighbours;
        }
        
        public int SumLiveNeighbours(State state, List<Coordinate> neighbourCoordinates)
        {
            var liveNeighbours = 0;
            
            foreach (var neighbourCoordinate in neighbourCoordinates)
            {
                var neighbourCell = new Cell(neighbourCoordinate, state);
                if (neighbourCell.State == State.Alive)
                {
                    liveNeighbours += 1;
                }
            }
            return liveNeighbours;
        }
        private int LastRowOrColumn()
        {
            return _universeDimensions - Constants.ZeroIndexAdjustmentValue;
        }
        private int NextRow(Coordinate coordinate)
        {
            return coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
        }
        private int NextColumn(Coordinate coordinate)
        {
            return coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
        }
        private int PreviousRow(Coordinate coordinate)
        {
            return coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
        }
        private int PreviousColumn(Coordinate coordinate)
        {
            return coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
        }
        private void CheckIfCorner(Cell cell)
        {
            var coordinate = cell.Coordinate;

            if (IsTopLeftCorner(coordinate))
            {
                cell.Orientation = Orientation.TopLeftCorner;
            }
            else if (IsTopRightCorner(coordinate))
            {
                cell.Orientation = Orientation.TopRightCorner;
            }
            else if (IsBottomLeftCorner(coordinate))
            {
                cell.Orientation = Orientation.BottomLeftCorner;
            }
            else if (IsBottomRightCorner(coordinate))
            {
                cell.Orientation = Orientation.BottomRightCorner;
            }
        }
        private void CheckIfSide(Cell cell) //try adding these to a list of functions
        {
            var coordinate = cell.Coordinate;

            if (IsTopSide(coordinate)) //loop through all the functions, if true _position = Position.{function name}
            {
                cell.Orientation = Orientation.TopSide;
            }
            else if (IsBottomSide(coordinate))
            {
                cell.Orientation = Orientation.BottomSide;
            }
            else if (IsLeftSide(coordinate))
            {
                cell.Orientation = Orientation.LeftSide;
            }
            else if (IsRightSide(coordinate))
            {
                cell.Orientation = Orientation.RightSide;
            }
        }
        private bool IsTopLeftCorner(Coordinate coordinate)
        {
            var topLeftCorner = new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            return HasSameCoordinates(topLeftCorner, coordinate);
        }
        private bool IsTopRightCorner(Coordinate coordinate)
        {
            var topRightCorner = new Coordinate(Constants.FirstRowOrColumn, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(topRightCorner, coordinate);
        }
        private bool IsBottomLeftCorner(Coordinate coordinate)
        {
            var bottomLeftCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            return HasSameCoordinates(bottomLeftCorner, coordinate);
        }
        private bool IsBottomRightCorner(Coordinate coordinate)
        {
            var bottomRightCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(bottomRightCorner, coordinate);
        }
        private bool IsTopSide(Coordinate coordinate)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Row, coordinate);
        }
        private bool IsBottomSide(Coordinate coordinate)
        {
            return IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Row, coordinate);
        }
        private bool IsLeftSide(Coordinate coordinate)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Column, coordinate);
        }
        private bool IsRightSide(Coordinate coordinate)
        {
            return IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Column, coordinate);
        }
        //checks
        private bool HasSameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        private bool IsSide(int referenceSide, int actualSide, Coordinate coordinate)
        {
            return actualSide == referenceSide && !IsCorner(coordinate);
        }
        private bool IsCorner(Coordinate coordinate)
        {
            return IsTopLeftCorner(coordinate) || IsTopRightCorner(coordinate) || IsBottomLeftCorner(coordinate) || IsBottomRightCorner(coordinate);
        }
    }
}           