using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.PositionType;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife
{
    public class NeighbourLocator
    {
        public readonly int NextRow;
        public readonly int NextColumn;
        public readonly int PreviousRow;
        public readonly int PreviousColumn;
        public readonly int LastRowOrColumn;
        private int _liveNeighbours;
        private List<State> _neighbourCellsState;
        private readonly int _sameRow;
        private readonly int _sameColumn;
        private readonly Coordinate _topLeftCorner;
        private readonly Coordinate _topRightCorner;
        private readonly Coordinate _bottomLeftCorner;
        private readonly Coordinate _bottomRightCorner;
        
        public NeighbourLocator(Cell cell, int universeDimensions)
        {
            NextRow = cell.Coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
            NextColumn = cell.Coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
            PreviousRow = cell.Coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
            PreviousColumn = cell.Coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
            LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;
            _sameRow = cell.Coordinate.Row;
            _sameColumn = cell.Coordinate.Column;
            _topLeftCorner = new Coordinate (Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            _topRightCorner = new Coordinate(Constants.FirstRowOrColumn, universeDimensions - Constants.ZeroIndexAdjustmentValue);
            _bottomLeftCorner = new Coordinate(universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            _bottomRightCorner = new Coordinate(universeDimensions - Constants.ZeroIndexAdjustmentValue, universeDimensions - Constants.ZeroIndexAdjustmentValue);
        }
        
        public int GetLiveNeighbours(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbourCellsState = new PositionTypeContext(cell.GetPositionType()).GetNeighbourCellsState(cell, universeGrid, universeDimensions);
            _liveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return _liveNeighbours;
        }

        public List<State> GetNeighbourCellsState(Cell[,] universeGrid, List<int> rows, List<int> columns)
        {
            
            _neighbourCellsState = new List<State>()
            {
                universeGrid[_sameRow, columns[0]].State, 
                universeGrid[_sameRow, columns[1]].State,
                
                universeGrid[rows[0], _sameColumn].State, 
                universeGrid[rows[0], columns[0]].State,
                universeGrid[rows[0], columns[1]].State,
                
                universeGrid[rows[1], _sameColumn].State,
                universeGrid[rows[1], columns[0]].State,
                universeGrid[rows[1], columns[1]].State
            };
            
            return _neighbourCellsState;
        }
        
        public void SetOrientation(Cell cell)
        {
            if (SameCoordinates(_topLeftCorner, cell.Coordinate))
            {
                cell.PositionType = PositionType.PositionType.TopLeftCorner;
            }
            else if (SameCoordinates(_topRightCorner, cell.Coordinate))
            {
                cell.PositionType = PositionType.PositionType.TopRightCorner;
            }
            else if (SameCoordinates(_bottomLeftCorner, cell.Coordinate))
            {
                cell.PositionType = PositionType.PositionType.BottomLeftCorner;
            }
            else if (SameCoordinates(_bottomRightCorner, cell.Coordinate))
            {
                cell.PositionType = PositionType.PositionType.BottomRightCorner;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Row))
            {
                cell.PositionType = PositionType.PositionType.TopSide;
            }
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Row))
            {
                cell.PositionType = PositionType.PositionType.BottomSide;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Column))
            {
                cell.PositionType = PositionType.PositionType.LeftSide;
            }
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Column))
            {
                cell.PositionType = PositionType.PositionType.RightSide;
            }
            else
            {
                cell.PositionType = PositionType.PositionType.Middle;
            }
        }
        
        private static bool SameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        
        private static bool SameSide(int referenceSide, int actualSide)
        {
            return actualSide == referenceSide;
        }
    }
}