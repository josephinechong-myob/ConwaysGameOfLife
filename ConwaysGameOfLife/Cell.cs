using System;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public State State;
        public Coordinate Coordinate { get; set; }
        private Orientation? _orientation;
        public string Symbol { get; set; }
        public ConsoleColor Colour { get; set; }
        public int NumberOfLiveNeighbours;
     
        
        public Cell(Coordinate coordinate, State state)
        {
            Coordinate = coordinate;
            State = state;
            Colour = state == State.Alive ? Constants.Alive : Constants.Dead;
            Symbol = Constants.SquareCell;
            //GridSymbol = State == State.Alive ? AliveCell : DeadCell;
            //GridSymbol = GetGridSymbol();
        }

        /*public Cell GetGridSymbol()
        {
            return GridSymbol = State == State.Alive ? AliveCellGridSymbol : DeadCellGridSymbol;
        }*/
        
        //print cell function 
        
        public bool IsAlive()
        { 
            return State == State.Alive;
        }
        
        public Orientation GetOrientation(Coordinate coordinate, int universeDimension)
        {
            CheckIfCorner(coordinate, universeDimension);
            CheckIfSide(coordinate, universeDimension);
            _orientation ??= Orientation.Middle;

            return (Orientation) _orientation;
        }

        /*public int GetLiveNeighbours(Coordinate coordinate, int universeDimension, State state)
        {
            return GetNeighboursOfTopLeftCornerCellPosition(coordinate, universeDimension, state);
        }*/

        /*
        private List<Cell> GetNeighboursOfTopLeftCornerCellPosition(int universeDimension)
        {
            var neighbourCoordinates = new List<Coordinate>()
            {
                new Coordinate(LastRowOrColumn(universeDimension), LastRowOrColumn(universeDimension)), //topLeftNeighbour
                new Coordinate(LastRowOrColumn(universeDimension), NextColumn(Coordinate)), //topRightNeighbour
                new Coordinate(NextRow(Coordinate), LastRowOrColumn(universeDimension)), //bottomLeftNeighbour
                new Coordinate(NextRow(Coordinate), NextColumn(Coordinate)),// same as middle type cell bottom right ~ bottomRightNeighbour 
                new Coordinate(LastRowOrColumn(universeDimension), Constants.FirstRowOrColumn), //topNeighbour
                new Coordinate(NextRow(Coordinate), Constants.FirstRowOrColumn), // same as middle type cell ~ bottomNeighbour
                new Coordinate(Constants.FirstRowOrColumn, LastRowOrColumn(universeDimension)), //leftNeighbour
                new Coordinate(Constants.FirstRowOrColumn, NextColumn(Coordinate)) //same as middle type cell ~ rightNeighbour
            };

            var neighbourCells = new List<Cell>();

            foreach (var neighbourCoordinate in neighbourCoordinates)
            {
                var neighbourCell = ;
                neighbourCells.Add(neighbourCell);
            }
        }
        */
        
        /*public int SumLiveNeighbours(State state, List<Coordinate> neighbourCoordinates)
        {
            var liveNeighbours = 0;
            
            foreach (var neighbourCoordinate in neighbourCoordinates)
            {
                var neighbourCell = new Cell(state, neighbourCoordinate);
                if (neighbourCell.IsAlive())
                {
                    liveNeighbours += 1;
                }
            }
            return liveNeighbours;
        }*/
        
        private int LastRowOrColumn(int universeDimension)
        {
            return universeDimension - Constants.ZeroIndexAdjustmentValue;
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
        
        private void CheckIfCorner(Coordinate coordinate, int universeDimension)
        {
            if (IsTopLeftCorner(coordinate))
            {
                _orientation = Orientation.TopLeftCorner;
            }
            else if (IsTopRightCorner(coordinate, universeDimension))
            {
                _orientation = Orientation.TopRightCorner;
            }
            else if (IsBottomLeftCorner(coordinate, universeDimension))
            {
                _orientation = Orientation.BottomLeftCorner;
            }
            else if (IsBottomRightCorner(coordinate, universeDimension))
            {
                _orientation = Orientation.BottomRightCorner;
            }
        }
        
        private void CheckIfSide(Coordinate coordinate, int universeDimension) //try adding these to a list of functions
        {
            if (IsTopSide(coordinate, universeDimension)) //loop through all the functions, if true _position = Position.{function name}
            {
                _orientation = Orientation.TopSide;
            }
            else if (IsBottomSide(coordinate, universeDimension))
            {
                _orientation = Orientation.BottomSide;
            }
            else if (IsLeftSide(coordinate, universeDimension))
            {
                _orientation = Orientation.LeftSide;
            }
            else if (IsRightSide(coordinate, universeDimension))
            {
                _orientation = Orientation.RightSide;
            }
        }
        
        private bool IsTopLeftCorner(Coordinate coordinate)
        {
            var topLeftCorner = new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            return HasSameCoordinates(topLeftCorner, coordinate);
        }
        
        private bool IsTopRightCorner(Coordinate coordinate, int universeDimension)
        {
            var topRightCorner = new Coordinate(Constants.FirstRowOrColumn, universeDimension - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(topRightCorner, coordinate);
        }
        
        private bool IsBottomLeftCorner(Coordinate coordinate, int universeDimension)
        {
            var bottomLeftCorner = new Coordinate(universeDimension - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            return HasSameCoordinates(bottomLeftCorner, coordinate);
        }
        
        private bool IsBottomRightCorner(Coordinate coordinate, int universeDimension)
        {
            var bottomRightCorner = new Coordinate(universeDimension - Constants.ZeroIndexAdjustmentValue, universeDimension - Constants.ZeroIndexAdjustmentValue);
            return HasSameCoordinates(bottomRightCorner, coordinate);
        }
        
        private bool IsTopSide(Coordinate coordinate, int universeDimension)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Row, coordinate, universeDimension);
        }

        private bool IsBottomSide(Coordinate coordinate, int universeDimension)
        {
            return IsSide(universeDimension - Constants.ZeroIndexAdjustmentValue, coordinate.Row, coordinate, universeDimension);
        }

        private bool IsLeftSide(Coordinate coordinate, int universeDimension)
        {
            return IsSide(Constants.FirstRowOrColumn, coordinate.Column, coordinate, universeDimension);
        }

        private bool IsRightSide(Coordinate coordinate, int universeDimension)
        {
            return IsSide(universeDimension - Constants.ZeroIndexAdjustmentValue, coordinate.Column, coordinate, universeDimension);
        }
        
        //checks
        private bool HasSameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }

        private bool IsSide(int referenceSide, int actualSide, Coordinate coordinate, int universeDimension)
        {
            return actualSide == referenceSide && !IsCorner(coordinate, universeDimension);
        }

        private bool IsCorner(Coordinate coordinate, int universeDimension)
        {
            return IsTopLeftCorner(coordinate) || IsTopRightCorner(coordinate, universeDimension) || IsBottomLeftCorner(coordinate, universeDimension) || IsBottomRightCorner(coordinate, universeDimension);
        }
    }
}