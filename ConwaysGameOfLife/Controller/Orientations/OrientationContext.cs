using System;
using System.Collections.Generic;
using ConwaysGameOfLife.Controller.Orientations.Strategies;
using ConwaysGameOfLife.Model;

namespace ConwaysGameOfLife.Controller.Orientations
{
    public class OrientationContext
    {
        private readonly Orientation _orientation;
        public OrientationContext(Orientation orientation)
        {
            _orientation = orientation;
        }
        public List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            switch (_orientation)
            {
                case Orientation.TopLeftCorner:
                    return TopLeftCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.TopRightCorner:
                    return TopRightCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.BottomLeftCorner:
                    return BottomLeftCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.BottomRightCorner:
                    return BottomRightCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.TopSide:
                    return TopSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.BottomSide:
                    return BottomSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.LeftSide:
                    return LeftSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.RightSide:
                    return RightSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case Orientation.Middle:
                    return MiddleStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                default: throw new ArgumentException(Constants.InvalidOrientation);
            }
        }
    }
}