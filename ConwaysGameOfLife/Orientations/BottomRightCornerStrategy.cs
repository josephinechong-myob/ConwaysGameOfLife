using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class BottomRightCornerStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            var rows = new List<int> {neighbour.PreviousRow, Constants.FirstRowOrColumn};
            var columns = new List<int> {Constants.FirstRowOrColumn, neighbour.PreviousColumn};
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, rows, columns);
            return neighbourCellsState;
        }
    }
}