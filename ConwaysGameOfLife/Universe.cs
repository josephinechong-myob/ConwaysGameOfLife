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
        private readonly int _lastRowOrColumn;
        private readonly Coordinate _topLeftCorner;
        private readonly Coordinate _topRightCorner;
        private readonly Coordinate _bottomLeftCorner;
        private readonly Coordinate _bottomRightCorner;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            
            UniverseGrid = seed.SeedGrid;
            _universeDimensions = seed.SeedDimensions;
            
            _lastRowOrColumn = _universeDimensions - Constants.ZeroIndexAdjustmentValue;
            _topLeftCorner = new Coordinate (Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            _topRightCorner = new Coordinate(Constants.FirstRowOrColumn, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
            _bottomLeftCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            _bottomRightCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
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
        
        public int GetLiveNeighbours(Cell cell)
        {
            if (cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.TopRightCorner || cell.Orientation == Orientation.BottomLeftCorner || cell.Orientation == Orientation.BottomRightCorner)
            {
                _liveNeighbours = GetLiveNeighboursForCornerCell(cell); 
            }
            else if (cell.Orientation == Orientation.TopSide || cell.Orientation == Orientation.BottomSide || cell.Orientation == Orientation.LeftSide || cell.Orientation == Orientation.RightSide)
            {
                _liveNeighbours = GetLiveNeighboursForSideCell(cell); 
            }
            else if (cell.Orientation == Orientation.Middle)
            {
                _liveNeighbours = GetLiveNeighboursForMiddleCell(cell); 
            }
            return _liveNeighbours;
        }

        private int GetLiveNeighboursForMiddleCell(Cell cell)
        {
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[PreviousRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State, 
                UniverseGrid[PreviousRow(cell.Coordinate), NextColumn(cell.Coordinate)].State,
                UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State,
                UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State, 
                UniverseGrid[NextRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State,
                UniverseGrid[NextRow(cell.Coordinate), NextColumn(cell.Coordinate)].State
            };
            
            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return numberOfLiveNeighbours;
        }
        
        private int GetLiveNeighboursForCornerCell(Cell cell)
        {
            /*int firstRow = TopCorners(cell) ? Constants.FirstRowOrColumn : _lastRowOrColumn;
            int secondRow = TopCorners(cell) ? _lastRowOrColumn : Constants.FirstRowOrColumn;
            int thirdRow = TopCorners(cell) ? NextRow(cell.Coordinate) : PreviousRow(cell.Coordinate);
            int firstColumn = BottomCorners(cell) ? _lastRowOrColumn : Constants.FirstRowOrColumn;
            int secondColumn = BottomCorners(cell) ? NextColumn(cell.Coordinate) : PreviousColumn(cell.Coordinate);
            
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[firstRow, firstColumn].State,
                UniverseGrid[secondRow, _lastRowOrColumn].State, 
                UniverseGrid[secondRow, Constants.FirstRowOrColumn].State,
                UniverseGrid[thirdRow, secondColumn].State,
                UniverseGrid[_lastRowOrColumn, secondColumn].State, 
                UniverseGrid[Constants.FirstRowOrColumn, secondColumn].State,
                UniverseGrid[thirdRow, Constants.FirstRowOrColumn].State,
                UniverseGrid[thirdRow, _lastRowOrColumn].State
            };
            */
            var neighbourCellsState = new List<State>();
            
            if (cell.Orientation == Orientation.TopLeftCorner)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State,
                    UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State, 
                    UniverseGrid[NextRow(cell.Coordinate), NextColumn(cell.Coordinate)].State,
                    UniverseGrid[cell.Coordinate.Row, _lastRowOrColumn].State,
                    UniverseGrid[NextRow(cell.Coordinate), _lastRowOrColumn].State, 
                    UniverseGrid[_lastRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[_lastRowOrColumn, NextColumn(cell.Coordinate)].State,
                    UniverseGrid[_lastRowOrColumn, _lastRowOrColumn].State
                };
            }

            if (cell.Orientation == Orientation.TopRightCorner)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[cell.Coordinate.Row, Constants.FirstRowOrColumn].State, 
                    UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[NextRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[NextRow(cell.Coordinate), Constants.FirstRowOrColumn].State, 
                    UniverseGrid[_lastRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[_lastRowOrColumn, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[_lastRowOrColumn, Constants.FirstRowOrColumn].State
                };
            }

            if (cell.Orientation == Orientation.BottomLeftCorner)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State,
                    UniverseGrid[cell.Coordinate.Row, _lastRowOrColumn].State, 
                    UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[PreviousRow(cell.Coordinate),NextColumn(cell.Coordinate)].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), _lastRowOrColumn].State, 
                    UniverseGrid[Constants.FirstRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[Constants.FirstRowOrColumn, NextColumn(cell.Coordinate)].State,
                    UniverseGrid[Constants.FirstRowOrColumn, _lastRowOrColumn].State
                };

            }

            if (cell.Orientation == Orientation.BottomRightCorner)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State, 
                    UniverseGrid[PreviousRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[Constants.FirstRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[Constants.FirstRowOrColumn, PreviousColumn(cell.Coordinate)].State, 
                    UniverseGrid[cell.Coordinate.Row, Constants.FirstRowOrColumn].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), Constants.FirstRowOrColumn].State,
                    UniverseGrid[Constants.FirstRowOrColumn, Constants.FirstRowOrColumn].State
                };
            }
            
            
            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return numberOfLiveNeighbours;
        }
        
        private int GetLiveNeighboursForSideCell(Cell cell)
        {
            var neighbourCellsState = new List<State>();
            
            if (cell.Orientation == Orientation.TopSide)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State, 
                    UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[NextRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[NextRow(cell.Coordinate), NextColumn(cell.Coordinate)].State, 
                    UniverseGrid[_lastRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[_lastRowOrColumn, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[_lastRowOrColumn, NextColumn(cell.Coordinate)].State
                };
            }
            
            if (cell.Orientation == Orientation.BottomSide)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State, 
                    UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), NextColumn(cell.Coordinate)].State, 
                    UniverseGrid[Constants.FirstRowOrColumn, cell.Coordinate.Column].State,
                    UniverseGrid[Constants.FirstRowOrColumn, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[Constants.FirstRowOrColumn, NextColumn(cell.Coordinate)].State
                };
            }
            
            if (cell.Orientation == Orientation.LeftSide)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State, 
                    UniverseGrid[cell.Coordinate.Row, NextColumn(cell.Coordinate)].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), NextColumn(cell.Coordinate)].State,
                    UniverseGrid[NextRow(cell.Coordinate), NextColumn(cell.Coordinate)].State, 
                    UniverseGrid[cell.Coordinate.Row, _lastRowOrColumn].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), _lastRowOrColumn].State,
                    UniverseGrid[NextRow(cell.Coordinate), _lastRowOrColumn].State
                };
            }
            
            if (cell.Orientation == Orientation.RightSide)
            {
                neighbourCellsState = new List<State>()
                {
                    UniverseGrid[PreviousRow(cell.Coordinate), cell.Coordinate.Column].State,
                    UniverseGrid[NextRow(cell.Coordinate), cell.Coordinate.Column].State, 
                    UniverseGrid[cell.Coordinate.Row, PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State,
                    UniverseGrid[NextRow(cell.Coordinate), PreviousColumn(cell.Coordinate)].State, 
                    UniverseGrid[cell.Coordinate.Row, Constants.FirstRowOrColumn].State,
                    UniverseGrid[PreviousRow(cell.Coordinate), Constants.FirstRowOrColumn].State,
                    UniverseGrid[NextRow(cell.Coordinate), Constants.FirstRowOrColumn].State
                };
            }
            
            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return numberOfLiveNeighbours;
        }
        
        public void SetOrientation(Cell cell)
        {
            if (SameCoordinates(_topLeftCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.TopLeftCorner;
            }
            else if (SameCoordinates(_topRightCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.TopRightCorner;
            }
            else if (SameCoordinates(_bottomLeftCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomLeftCorner;
            }
            else if (SameCoordinates(_bottomRightCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomRightCorner;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.TopSide;
            }
            else if (SameSide(_lastRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.BottomSide;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.LeftSide;
            }
            else if (SameSide(_lastRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.RightSide;
            }
            else
            {
                cell.Orientation = Orientation.Middle;
            }
        }
        private bool TopCorners(Cell cell)
        {
            return cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.TopRightCorner;
        }
        private bool BottomCorners(Cell cell)
        {
            return cell.Orientation == Orientation.BottomRightCorner || cell.Orientation == Orientation.BottomLeftCorner;
        }
        private bool SameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        private bool SameSide(int referenceSide, int actualSide)
        {
            return actualSide == referenceSide;
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
    }
}

/*public void CreateUniverse() //is this still needed?
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
        }*/

/*public int SumLiveNeighbours(State state, List<Coordinate> neighbourCoordinates)
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
        }*/