using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class LeftSideStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            
            var firstRow = neighbour.PreviousRow;
            var secondRow = neighbour.NextRow;
            var firstColumn = neighbour.LastRowOrColumn;
            var secondColumn = neighbour.NextColumn;
            
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, firstRow, secondRow, firstColumn, secondColumn);
            return neighbourCellsState;
        }
    }
}