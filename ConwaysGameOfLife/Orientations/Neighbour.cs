using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public class Neighbour
    {
        private List<State> _neighbourCellsState;
        private readonly int _sameRow;
        public readonly int NextRow;
        public readonly int PreviousRow;
        private readonly int _sameColumn;
        public readonly int NextColumn;
        public readonly int PreviousColumn;
        public readonly int LastRowOrColumn;
        
        public Neighbour(Cell cell, int universeDimensions)
        {
            _sameRow = cell.Coordinate.Row;
            NextRow = cell.Coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
            PreviousRow = cell.Coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
            _sameColumn = cell.Coordinate.Column;
            NextColumn = cell.Coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
            PreviousColumn = cell.Coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
            LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;LastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;
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