using System;
using System.Collections.Generic;
using ConwaysGameOfLife.States;
using ConwaysGameOfLife.Strategies;

namespace ConwaysGameOfLife.PositionType
{
    public class PositionTypeContext
    {
        private readonly PositionType _positionType;
        public PositionTypeContext(PositionType positionType)
        {
            _positionType = positionType;
        }
        public List<State> GetNeighbourCellsState(Cell cell, Cell[,] universeGrid, int universeDimensions)
        {
            switch (_positionType)
            {
                case PositionType.TopLeftCorner:
                    return TopLeftCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.TopRightCorner:
                    return TopRightCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.BottomLeftCorner:
                    return BottomLeftCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.BottomRightCorner:
                    return BottomRightCornerStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.TopSide:
                    return TopSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.BottomSide:
                    return BottomSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.LeftSide:
                    return LeftSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.RightSide:
                    return RightSideStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                case PositionType.Middle:
                    return MiddleStrategy.GetNeighbourCellsState(cell, universeGrid, universeDimensions);
                
                default: throw new ArgumentException(Constants.InvalidOrientation);
            }
        }
    }
}