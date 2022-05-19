using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public Coordinate Coordinate { get; set; }
        public Orientation? _orientation; //might not be needed
        public string Symbol { get; }
        public ConsoleColor Colour { get; set; }
        public int NumberOfLiveNeighbours;
        public State State;

        public Cell(Coordinate coordinate, State state) //update state based on live neighbours
        {
            Coordinate = coordinate;
            State = state;
            Colour = state == State.Alive ? Constants.Alive : Constants.Dead;
            Symbol = Constants.SquareCell;
        }

        /*public void UpdateCellState(Coordinate coordinate, int dimensions, State state)
        {
            GetOrientation(coordinate, dimensions); //need orientation for live neighbours
            var liveNeighbours = GetLiveNeighbours(coordinate, dimensions, state);
            State = StateLaws.UpdateState(state, liveNeighbours);
        }*/

        /*public Orientation GetOrientation(Coordinate coordinate, int universeDimension)
        {
            CheckIfCorner(coordinate, universeDimension);
            CheckIfSide(coordinate, universeDimension);
            _orientation ??= Orientation.Middle;

            return (Orientation) _orientation;
        }*/

        /*public int GetLiveNeighbours(int universeDimension, Universe universe)
        {
            return GetLiveNeighboursOfTopLeftCornerCellPosition(universeDimension, universe);
        }

        private int GetLiveNeighboursOfTopLeftCornerCellPosition(int universeDimension, Universe universe) //not sure if i should be passing in universe
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
            
            var neighbourCells = new List<Cell>() //get coordinates - how to get cell state if I know coordinate?
            {
                new Cell(neighbourCoordinates[0], universe.UniverseGrid[LastRowOrColumn(universeDimension), LastRowOrColumn(universeDimension)].State), 
                new Cell(neighbourCoordinates[1], universe.UniverseGrid[LastRowOrColumn(universeDimension), NextColumn(Coordinate)].State), 
                new Cell(neighbourCoordinates[2], universe.UniverseGrid[NextRow(Coordinate), LastRowOrColumn(universeDimension)].State ), 
                new Cell(neighbourCoordinates[3], universe.UniverseGrid[NextRow(Coordinate), NextColumn(Coordinate)].State),
                new Cell(neighbourCoordinates[4], universe.UniverseGrid[LastRowOrColumn(universeDimension), Constants.FirstRowOrColumn].State), 
                new Cell(neighbourCoordinates[5], universe.UniverseGrid[NextRow(Coordinate), Constants.FirstRowOrColumn].State), 
                new Cell(neighbourCoordinates[6], universe.UniverseGrid[Constants.FirstRowOrColumn, LastRowOrColumn(universeDimension)].State),
                new Cell(neighbourCoordinates[7], universe.UniverseGrid[Constants.FirstRowOrColumn, NextColumn(Coordinate)].State)
            };

            var liveNeighbourCells = new List<Cell>();

            foreach (var cell in neighbourCells)
            {
                if (State == State.Alive)
                {
                    liveNeighbourCells.Add(cell);
                }
            }

            return liveNeighbourCells.Count;
        }*/
        
        /*public int SumLiveNeighbours(State state, List<Coordinate> neighbourCoordinates)
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
        }*/
        
        /*private int LastRowOrColumn(int universeDimension)
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
        }*/
        
        /*private void CheckIfCorner(Coordinate coordinate, int universeDimension)
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
        }*/
        
        /*private bool IsTopLeftCorner(Coordinate coordinate)
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
        }*/
        
        /*//checks
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
        }*/
    }
}