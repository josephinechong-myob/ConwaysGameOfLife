using System.Collections.Generic;

namespace ConwaysGameOfLife.Orientations
{
    public static class LeftSideStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            var rows = new List<int> {neighbour.PreviousRow, neighbour.NextRow};
            var columns = new List<int> {neighbour.LastRowOrColumn, neighbour.NextColumn};
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, rows, columns);
            return neighbourCellsState;
        }
    }
}