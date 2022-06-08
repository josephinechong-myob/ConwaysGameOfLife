using System.Collections.Generic;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife.Strategies
{
    public static class TopLeftCornerStrategy
    {
        public static List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            var neighbour = new NeighbourLocator(cell, universeDimensions);
            var rows = new List<int> {neighbour.LastRowOrColumn, neighbour.NextRow};
            var columns = new List<int> {neighbour.LastRowOrColumn, neighbour.NextColumn};
            var neighbourCellsState = neighbour.GetNeighbourCellsState(universeGrid, rows, columns);
            return neighbourCellsState;
        }
    }
}