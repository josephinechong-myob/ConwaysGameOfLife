using System.Linq;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
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
        
        public Neighbour(Cell cell, int universeDimensions)
        {
            _sameRow = cell.Coordinate.Row;
            _sameColumn = cell.Coordinate.Column;
            NextRow = cell.Coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
            NextColumn = cell.Coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
            PreviousRow = cell.Coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
            PreviousColumn = cell.Coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
            LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;
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
    }
}