using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IGameConsole GameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }
        private readonly int _universeDimensions;
        private int _liveNeighbours;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
            _universeDimensions = seed.SeedDimensions;
        }
        public void CreateUniverse() //is this still needed?
        {
            var width = UniverseGrid.GetUpperBound(0) + 1;
            var height = UniverseGrid.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var state = Generation == 0 ? State.Dead : UniverseGrid[x, y].State;
                    UniverseGrid[x, y] = new Cell(new Coordinate(x, y), state);
                }
            }
        }
        
        public void DisplayUniverse(Cell[,] universe)
        {
            //var displayString = "";
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GameConsole.ForegroundColor(universe[i, j].Colour);
                    GameConsole.Write(universe[i, j].Symbol);
                }
                GameConsole.Write("\n");
            }
        }
        
        
        public int GetLiveNeighbours(Cell cell)
        {
            _liveNeighbours = GetLiveNeighboursForCornerCell(cell);
            
            return _liveNeighbours;
        }
        
        private int GetLiveNeighboursForCornerCell(Cell cell)
        {
            int firstRow;
            int secondRow;
            int thirdRow;
            int firstColumn;
            int secondColumn;
            
            if (cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.TopRightCorner)
            {
                firstRow = Constants.FirstRowOrColumn;
                secondRow = LastRowOrColumn();
                thirdRow = NextRow(cell.Coordinate);
            }
            else
            {
                firstRow = LastRowOrColumn();
                secondRow = Constants.FirstRowOrColumn;
                thirdRow = PreviousRow(cell.Coordinate);
            }

            if (cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.BottomLeftCorner)
            {
                firstColumn = LastRowOrColumn();
                secondColumn = NextColumn(cell.Coordinate);
            }
            else
            {
                firstColumn = Constants.FirstRowOrColumn;
                secondColumn = PreviousColumn(cell.Coordinate);
            }
            
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[firstRow, firstColumn].State,
                UniverseGrid[secondRow, LastRowOrColumn()].State, 
                UniverseGrid[secondRow, Constants.FirstRowOrColumn].State,
                UniverseGrid[thirdRow, secondColumn].State,
                UniverseGrid[LastRowOrColumn(), secondColumn].State, 
                UniverseGrid[Constants.FirstRowOrColumn, secondColumn].State,
                UniverseGrid[thirdRow, Constants.FirstRowOrColumn].State,
                UniverseGrid[thirdRow, LastRowOrColumn()].State
            };
            
            var numberOfLiveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return numberOfLiveNeighbours;
        }
        
        public int SumLiveNeighbours(State state, List<Coordinate> neighbourCoordinates)
        {
            var liveNeighbours = 0;
            
            foreach (var neighbourCoordinate in neighbourCoordinates)
            {
                var neighbourCell = new Cell(neighbourCoordinate, state);
                if (neighbourCell.State == State.Alive)
                {
                    liveNeighbours += 1;
                }
            }
            return liveNeighbours;
        }
        
        
        public void SetOrientation(Cell cell)
        {
            if (HasSameCoordinates(new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn),
                cell.Coordinate))
            {
                cell.Orientation = Orientation.TopLeftCorner;
            }
            else if (HasSameCoordinates(
                new Coordinate(Constants.FirstRowOrColumn, _universeDimensions - Constants.ZeroIndexAdjustmentValue),
                cell.Coordinate))
            {
                cell.Orientation = Orientation.TopRightCorner;
            }
            else if (HasSameCoordinates(
                new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn),
                cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomLeftCorner;
            }
            else if (HasSameCoordinates(
                new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue,
                    _universeDimensions - Constants.ZeroIndexAdjustmentValue), cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomRightCorner;
            }
            else if (IsSide(Constants.FirstRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.TopSide;
            }
            else if (IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.BottomSide;
            }
            else if (IsSide(Constants.FirstRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.LeftSide;
            }
            else if (IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.RightSide;
            }
            else
            {
                cell.Orientation = Orientation.Middle;
            }
        }
        
        private bool HasSameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        private bool IsSide(int referenceSide, int actualSide)
        {
            return actualSide == referenceSide;
        }
        
        private int LastRowOrColumn()
        {
            return _universeDimensions - Constants.ZeroIndexAdjustmentValue;
        }
        private int NextRow(Coordinate coordinate)
        {
            return coordinate.Row + Constants.NeighbourPositionAdjustmentValue;
        }
        private int NextColumn(Coordinate coordinate)
        {
            return coordinate.Column + Constants.NeighbourPositionAdjustmentValue;
        }
        private int PreviousRow(Coordinate coordinate)
        {
            return coordinate.Row - Constants.NeighbourPositionAdjustmentValue;
        }
        private int PreviousColumn(Coordinate coordinate)
        {
            return coordinate.Column - Constants.NeighbourPositionAdjustmentValue;
        }
    }
}
/*private bool TopSide(Coordinate coordinate)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Row, coordinate);
        }*/
/*private bool BottomSide(Coordinate coordinate)
{
    return IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Row, coordinate);
}*/
/*private bool LeftSide(Coordinate coordinate)
{
    return IsSide(Constants.FirstRowOrColumn, coordinate.Column, coordinate);
}*/
/*private bool RightSide(Coordinate coordinate)
{
    return IsSide(_universeDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Column, coordinate);
}*/

/*private bool TopLeftCorner(Coordinate coordinate)
       {
           var topLeftCorner = new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
           return HasSameCoordinates(topLeftCorner, coordinate);
       }*/
/*private bool TopRightCorner(Coordinate coordinate)
{
    var topRightCorner = new Coordinate(Constants.FirstRowOrColumn, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
    return HasSameCoordinates(topRightCorner, coordinate);
}*/
/*private bool BottomLeftCorner(Coordinate coordinate)
{
    var bottomLeftCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
    return HasSameCoordinates(bottomLeftCorner, coordinate);
}*/
/*private bool BottomRightCorner(Coordinate coordinate)
{
    var bottomRightCorner = new Coordinate(_universeDimensions - Constants.ZeroIndexAdjustmentValue, _universeDimensions - Constants.ZeroIndexAdjustmentValue);
    return HasSameCoordinates(bottomRightCorner, coordinate);
}*/

/*private bool IsCorner(Coordinate coordinate)
        {
            return TopLeftCorner(coordinate) || TopRightCorner(coordinate) || BottomLeftCorner(coordinate) || BottomRightCorner(coordinate);
        }*/
        
/*private void CheckIfSide(Cell cell) //try adding these to a list of functions
{
    var coordinate = cell.Coordinate;

    if (TopSide(coordinate)) //loop through all the functions, if true _position = Position.{function name}
    {
        cell.Orientation = Orientation.TopSide;
    }
    else if (BottomSide(coordinate))
    {
        cell.Orientation = Orientation.BottomSide;
    }
    else if (LeftSide(coordinate))
    {
        cell.Orientation = Orientation.LeftSide;
    }
    else if (RightSide(coordinate))
    {
        cell.Orientation = Orientation.RightSide;
    }
}*/
/*private void CheckIfCorner(Cell cell)
        {
            var coordinate = cell.Coordinate;

            if (TopLeftCorner(coordinate))
            {
                cell.Orientation = Orientation.TopLeftCorner;
            }
            else if (TopRightCorner(coordinate))
            {
                cell.Orientation = Orientation.TopRightCorner;
            }
            else if (BottomLeftCorner(coordinate))
            {
                cell.Orientation = Orientation.BottomLeftCorner;
            }
            else if (BottomRightCorner(coordinate))
            {
                cell.Orientation = Orientation.BottomRightCorner;
            }
        }*/
        
/*private bool IsSide(int referenceSide, int actualSide, Coordinate coordinate)
{
    return actualSide == referenceSide && !IsCorner(coordinate);
}*/

/*public void GetOrientation(Cell cell)
        {
            CheckIfCorner(cell);
            CheckIfSide(cell);
            cell.Orientation ??= Orientation.Middle;
        }*/