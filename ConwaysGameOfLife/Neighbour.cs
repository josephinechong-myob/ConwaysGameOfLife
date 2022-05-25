using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Orientations;

namespace ConwaysGameOfLife
{
    public class Neighbour
    {
        private int _liveNeighbours;
        private List<State> _neighbourCellsState;
        private readonly int _sameRow;
        private readonly int _sameColumn;
        public readonly int NextRow;
        public readonly int NextColumn;
        public readonly int PreviousRow;
        public readonly int PreviousColumn;
        public readonly int LastRowOrColumn;
        private readonly Coordinate _topLeftCorner;
        private readonly Coordinate _topRightCorner;
        private readonly Coordinate _bottomLeftCorner;
        private readonly Coordinate _bottomRightCorner;
        
        public Neighbour(Cell cell, int universeDimensions)
        {
            _sameRow = cell.Coordinate.Row;
            _sameColumn = cell.Coordinate.Column;
            NextRow = cell.Coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
            NextColumn = cell.Coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
            PreviousRow = cell.Coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
            PreviousColumn = cell.Coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
            LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;
            _topLeftCorner = new Coordinate (Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            _topRightCorner = new Coordinate(Constants.FirstRowOrColumn, universeDimensions - Constants.ZeroIndexAdjustmentValue);
            _bottomLeftCorner = new Coordinate(universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            _bottomRightCorner = new Coordinate(universeDimensions - Constants.ZeroIndexAdjustmentValue, universeDimensions - Constants.ZeroIndexAdjustmentValue);
        }
        
        public int GetLiveNeighbours(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbourCellsState = new OrientationContext(cell.Orientation).GetNeighbourCellsState(cell, universeGrid, universeDimensions);
            _liveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return _liveNeighbours;
        }

        public List<State> GetNeighbourCellsState(Cell[,] universeGrid, int firstRow, int secondRow, int firstColumn, int secondColumn)
        {
            _neighbourCellsState = new List<State>()
            {
                universeGrid[_sameRow, firstColumn].State, 
                universeGrid[_sameRow, secondColumn].State,
                
                universeGrid[firstRow, _sameColumn].State, 
                universeGrid[firstRow, firstColumn].State,
                universeGrid[firstRow, secondColumn].State,
                
                universeGrid[secondRow, _sameColumn].State,
                universeGrid[secondRow, firstColumn].State,
                universeGrid[secondRow, secondColumn].State
            };
            
            return _neighbourCellsState;
        }
        
        private bool SameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        
        private bool SameSide(int referenceSide, int actualSide)
        {
            return actualSide == referenceSide;
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
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.BottomSide;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.LeftSide;
            }
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.RightSide;
            }
            else
            {
                cell.Orientation = Orientation.Middle;
            }
        }
    }
}