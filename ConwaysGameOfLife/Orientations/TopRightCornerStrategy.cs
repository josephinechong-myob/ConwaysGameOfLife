using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class TopRightCornerStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            
            var firstRow = neighbour.LastRowOrColumn;
            var secondRow = neighbour.NextRow;
            var firstColumn = Constants.FirstRowOrColumn;
            var secondColumn = neighbour.PreviousColumn;
            
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, firstRow, secondRow, firstColumn, secondColumn);
            return neighbourCellsState;
        }
    }
}