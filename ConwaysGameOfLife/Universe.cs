using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IGameConsole GameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }
        public int UniverseDimensions;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            UniverseGrid = seed.SeedGrid;
            UniverseDimensions = seed.SeedDimensions;
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
        
        public void GetOrientation(Cell cell)
        {
            CheckIfCorner(cell);
            CheckIfSide(cell);
            cell._orientation ??= Orientation.Middle;
        }

        public int GetLiveNeighbours(Cell cell)
        {
            return GetLiveNeighboursOfTopLeftCornerCellPosition(cell);
        }

        private int GetLiveNeighboursOfTopLeftCornerCellPosition(Cell Cell)
        {
            var Coordinate = Cell.Coordinate;

            var neighbourCoordinates = new List<Coordinate>()
            {
                new Coordinate(LastRowOrColumn(), LastRowOrColumn()), //topLeftNeighbour
                new Coordinate(LastRowOrColumn(), NextColumn(Coordinate)), //topRightNeighbour
                new Coordinate(NextRow(Coordinate), LastRowOrColumn()), //bottomLeftNeighbour
                new Coordinate(NextRow(Coordinate), NextColumn(Coordinate)),// same as middle type cell bottom right ~ bottomRightNeighbour 
                new Coordinate(LastRowOrColumn(), Constants.FirstRowOrColumn), //topNeighbour
                new Coordinate(NextRow(Coordinate), Constants.FirstRowOrColumn), // same as middle type cell ~ bottomNeighbour
                new Coordinate(Constants.FirstRowOrColumn, LastRowOrColumn()), //leftNeighbour
                new Coordinate(Constants.FirstRowOrColumn, NextColumn(Coordinate)) //same as middle type cell ~ rightNeighbour
            };
            
            var neighbourCells = new List<Cell>() //get coordinates - how to get cell state if I know coordinate?
            {
                new Cell(neighbourCoordinates[0], UniverseGrid[LastRowOrColumn(), LastRowOrColumn()].State), 
                new Cell(neighbourCoordinates[1], UniverseGrid[LastRowOrColumn(), NextColumn(Coordinate)].State), 
                new Cell(neighbourCoordinates[2], UniverseGrid[NextRow(Coordinate), LastRowOrColumn()].State ), 
                new Cell(neighbourCoordinates[3], UniverseGrid[NextRow(Coordinate), NextColumn(Coordinate)].State),
                new Cell(neighbourCoordinates[4], UniverseGrid[LastRowOrColumn(), Constants.FirstRowOrColumn].State), 
                new Cell(neighbourCoordinates[5], UniverseGrid[NextRow(Coordinate), Constants.FirstRowOrColumn].State), 
                new Cell(neighbourCoordinates[6], UniverseGrid[Constants.FirstRowOrColumn, LastRowOrColumn()].State),
                new Cell(neighbourCoordinates[7], UniverseGrid[Constants.FirstRowOrColumn, NextColumn(Coordinate)].State)
            };

            var liveNeighbourCells = new List<Cell>();

            foreach (var cell in neighbourCells)
            {
                if (cell.State == State.Alive)
                {
                    liveNeighbourCells.Add(cell);
                }
            }

            return liveNeighbourCells.Count;
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
        private int LastRowOrColumn()
        {
            return UniverseDimensions - Constants.ZeroIndexAdjustmentValue;
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
        private void CheckIfCorner(Cell cell)
        {
            var coordinate = cell.Coordinate;

            if (IsTopLeftCorner(coordinate))
            {
                cell._orientation = Orientation.TopLeftCorner;
            }
            else if (IsTopRightCorner(coordinate))
            {
                cell._orientation = Orientation.TopRightCorner;
            }
            else if (IsBottomLeftCorner(coordinate))
            {
                cell._orientation = Orientation.BottomLeftCorner;
            }
            else if (IsBottomRightCorner(coordinate))
            {
                cell._orientation = Orientation.BottomRightCorner;
            }
        }
        
        private void CheckIfSide(Cell cell) //try adding these to a list of functions
        {
            var coordinate = cell.Coordinate;

            if (IsTopSide(coordinate)) //loop through all the functions, if true _position = Position.{function name}
            {
                cell._orientation = Orientation.TopSide;
            }
            else if (IsBottomSide(coordinate))
            {
                cell._orientation = Orientation.BottomSide;
            }
            else if (IsLeftSide(coordinate))
            {
                cell._orientation = Orientation.LeftSide;
            }
            else if (IsRightSide(coordinate))
            {
                cell._orientation = Orientation.RightSide;
            }
        }
         private bool IsTopLeftCorner(Coordinate coordinate)
        {
            var topLeftCorner = new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            return HasSameCoordinates(topLeftCorner, coordinate);
        }
        
        private bool IsTopRightCorner(Coordinate coordinate)
        {
            var topRightCorner = new Coordinate(Constants.FirstRowOrColumn, UniverseDimensions - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(topRightCorner, coordinate);
        }
        
        private bool IsBottomLeftCorner(Coordinate coordinate)
        {
            var bottomLeftCorner = new Coordinate(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            return HasSameCoordinates(bottomLeftCorner, coordinate);
        }
        
        private bool IsBottomRightCorner(Coordinate coordinate)
        {
            var bottomRightCorner = new Coordinate(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, UniverseDimensions - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(bottomRightCorner, coordinate);
        }
        
        private bool IsTopSide(Coordinate coordinate)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Row, coordinate);
        }

        private bool IsBottomSide(Coordinate coordinate)
        {
            return IsSide(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Row, coordinate);
        }

        private bool IsLeftSide(Coordinate coordinate)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Column, coordinate);
        }

        private bool IsRightSide(Coordinate coordinate)
        {
            return IsSide(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, coordinate.Column, coordinate);
        }
        //checks
        private bool HasSameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }

        private bool IsSide(int referenceSide, int actualSide, Coordinate coordinate)
        {
            return actualSide == referenceSide && !IsCorner(coordinate);
        }

        private bool IsCorner(Coordinate coordinate)
        {
            return IsTopLeftCorner(coordinate) || IsTopRightCorner(coordinate) || IsBottomLeftCorner(coordinate) || IsBottomRightCorner(coordinate);
        }
    }
}           