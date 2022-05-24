using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class TopLeftCornerStrategy
    {
        private static int NextRow(Coordinate coordinate)
        {
            return coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
        }
        private static int NextColumn(Coordinate coordinate)
        {
            return coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
        }

        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var lastRowOrColumn = universeDimensions - Constants.ZeroIndexAdjustmentValue;
            var sameRow = cell.Coordinate.Row;
            var firstRow = lastRowOrColumn;
            var secondRow = NextRow(cell.Coordinate);
            var sameColumn = cell.Coordinate.Column;
            var firstColumn = lastRowOrColumn;
            var secondColumn = NextColumn(cell.Coordinate);
            
            var neighbourCellsState = new List<State>()
            {
                universeGrid[sameRow, firstColumn].State, 
                universeGrid[sameRow, secondColumn].State,
                
                universeGrid[firstRow, sameColumn].State, 
                universeGrid[firstRow, firstColumn].State,
                universeGrid[firstRow, secondColumn].State,
                
                universeGrid[secondRow, sameColumn].State,
                universeGrid[secondRow, firstColumn].State,
                universeGrid[secondRow, secondColumn].State
            };
            return neighbourCellsState;
        }
    }
}