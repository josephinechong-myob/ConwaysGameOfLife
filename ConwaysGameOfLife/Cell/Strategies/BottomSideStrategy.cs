using System.Collections.Generic;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife.Strategies
{
    public static class BottomSideStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new Neighbour(cell, universeDimensions);
            var rows = new List<int> {neighbour.PreviousRow, Constants.FirstRowOrColumn};
            var columns = new List<int> {neighbour.PreviousColumn, neighbour.NextColumn};
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, rows, columns);
            return neighbourCellsState;
        }
    }
}