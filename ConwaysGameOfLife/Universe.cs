using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Orientations;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IGameConsole GameConsole;
        public Cell[,] UniverseGrid { get; set; }
        public int Generation { get; set; }
        public readonly int UniverseDimensions;
        private int _liveNeighbours;
        public readonly int LastRowOrColumn;
        private readonly Coordinate _topLeftCorner;
        private readonly Coordinate _topRightCorner;
        private readonly Coordinate _bottomLeftCorner;
        private readonly Coordinate _bottomRightCorner;

        public Universe(IGameConsole gameConsole, Seed seed)
        {
            GameConsole = gameConsole;
            
            UniverseGrid = seed.SeedGrid;
            UniverseDimensions = seed.SeedDimensions;
            
            LastRowOrColumn = UniverseDimensions - Constants.ZeroIndexAdjustmentValue;
            _topLeftCorner = new Coordinate (Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);
            _topRightCorner = new Coordinate(Constants.FirstRowOrColumn, UniverseDimensions - Constants.ZeroIndexAdjustmentValue);
            _bottomLeftCorner = new Coordinate(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);
            _bottomRightCorner = new Coordinate(UniverseDimensions - Constants.ZeroIndexAdjustmentValue, UniverseDimensions - Constants.ZeroIndexAdjustmentValue);
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
            var neighbourCellsState = new OrientationContext(cell.Orientation).GetNeighbourCellsState(cell, UniverseGrid, UniverseDimensions);
            _liveNeighbours = neighbourCellsState.Count(n => n == State.Alive);
            return _liveNeighbours;
        }
        
        public void SetOrientation(Cell cell)
        {
            if (SameCoordinates(_topLeftCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.TopLeftCorner;
            }
            else if (SameCoordinates(_topRightCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.TopRightCorner;
            }
            else if (SameCoordinates(_bottomLeftCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomLeftCorner;
            }
            else if (SameCoordinates(_bottomRightCorner, cell.Coordinate))
            {
                cell.Orientation = Orientation.BottomRightCorner;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.TopSide;
            }
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Row))
            {
                cell.Orientation = Orientation.BottomSide;
            }
            else if (SameSide(Constants.FirstRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.LeftSide;
            }
            else if (SameSide(LastRowOrColumn, cell.Coordinate.Column))
            {
                cell.Orientation = Orientation.RightSide;
            }
            else
            {
                cell.Orientation = Orientation.Middle;
            }
        }

        private bool SameCoordinates(Coordinate referenceCoordinate, Coordinate actualCoordinate)
        {
            return actualCoordinate.Row == referenceCoordinate.Row && actualCoordinate.Column == referenceCoordinate.Column;
        }
        private bool SameSide(int referenceSide, int actualSide)
        {
            return actualSide == referenceSide;
        }
    }
}

/*public void CreateUniverse() //is this still needed?
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
        
        /*var sameRow = cell.Coordinate.Row;
            var firstRow = 0;
            var secondRow = 0;
            var sameColumn = cell.Coordinate.Column;
            var firstColumn = 0;
            var secondColumn = 0;

            if (cell.Orientation == Orientation.Middle || cell.Orientation ==  Orientation.LeftSide || cell.Orientation == Orientation.RightSide )
            {
                firstRow = PreviousRow(cell.Coordinate);
                secondRow = NextRow(cell.Coordinate);
            }
            if (cell.Orientation == Orientation.BottomSide || cell.Orientation == Orientation.BottomRightCorner || cell.Orientation == Orientation.BottomLeftCorner )
            {
                firstRow = PreviousRow(cell.Coordinate);
                secondRow = Constants.FirstRowOrColumn;
            }
            if (cell.Orientation == Orientation.TopSide || cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.TopRightCorner )
            {
                firstRow = _lastRowOrColumn;
                secondRow = NextRow(cell.Coordinate);
            }

            if (cell.Orientation == Orientation.Middle || cell.Orientation == Orientation.TopSide || cell.Orientation == Orientation.BottomSide)
            {
                firstColumn = PreviousColumn(cell.Coordinate);
                secondColumn = NextColumn(cell.Coordinate);
            }
            
            if (cell.Orientation == Orientation.TopLeftCorner || cell.Orientation == Orientation.BottomLeftCorner || cell.Orientation == Orientation.LeftSide)
            {
                firstColumn = _lastRowOrColumn;
                secondColumn = NextColumn(cell.Coordinate);
            }
            
            if (cell.Orientation == Orientation.TopRightCorner || cell.Orientation == Orientation.RightSide || cell.Orientation == Orientation.BottomRightCorner)
            {
                firstColumn = Constants.FirstRowOrColumn;
                secondColumn = PreviousColumn(cell.Coordinate);
            }
            
            var neighbourCellsState = new List<State>()
            {
                UniverseGrid[sameRow, firstColumn].State, 
                UniverseGrid[sameRow, secondColumn].State,
                
                UniverseGrid[firstRow, sameColumn].State, 
                UniverseGrid[firstRow, firstColumn].State,
                UniverseGrid[firstRow, secondColumn].State,
                
                UniverseGrid[secondRow, sameColumn].State,
                UniverseGrid[secondRow, firstColumn].State,
                UniverseGrid[secondRow, secondColumn].State
            };*/