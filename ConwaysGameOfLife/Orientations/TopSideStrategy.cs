using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class TopSideStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            
            var firstRow = neighbour.LastRowOrColumn;
            var secondRow = neighbour.NextRow;
            var firstColumn = neighbour.PreviousColumn;
            var secondColumn = neighbour.NextColumn;
            
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, firstRow, secondRow, firstColumn, secondColumn);
            return neighbourCellsState;
        }
    }
}