namespace ConwaysGameOfLife
{
    public class Cell
    {
        private readonly State _state;
        public Coordinate Coordinate;
        private Position _position;
        public int NumberOfLiveNeighbours;

        public Cell(State state)
        {
            _state = state;
        }
        public bool IsAlive()
        { 
            return _state == State.Alive;
        }

        public Position GetPosition(Coordinate coordinate, int universeDimension)
        {
            if (IsTopLeftCorner(coordinate, universeDimension))
            {
                _position = Position.TopLeftCorner;
            }
            else if (IsTopRightCorner(coordinate, universeDimension))
            {
                _position = Position.TopRightCorner;
            }
            else if (IsBottomLeftCorner(coordinate, universeDimension))
            {
                _position = Position.BottomLeftCorner;
            }
            else if (IsBottomRightCorner(coordinate, universeDimension))
            {
                _position = Position.BottomRightCorner;
            }
            else if (IsTopSide(coordinate, universeDimension))
            {
                _position = Position.TopSide;
            }
            else if (IsBottomSide(coordinate, universeDimension))
            {
                _position = Position.BottomSide;
            }
            else if (IsLeftSide(coordinate, universeDimension))
            {
                _position = Position.LeftSide;
            }
            else if (IsRightSide(coordinate, universeDimension))
            {
                _position = Position.RightSide;
            }
            else
            {
                _position = Position.Middle;
            }
            //_position = GetCorner(coordinate, universeDimension);
            //_position = GetSide(coordinate, universeDimension);
            
            return _position;
        }

        /*public int GetLiveNeighbour()
        {
            LiveDiagonalNeighbours();
        }

        private int LiveDiagonalNeighbours(Position position)
        {
            var liveNeighbours = 0;
            
            if (position == Position.Corner)
            {
                
            }
            else if (position == Position.Middle)
            {
                
            }
            else if (position == Position.Side)
            {
                
            }

            return liveNeighbours;
        }*/
        
        private Position GetCorner(Coordinate coordinate, int universeDimension)
        {
             if (IsTopLeftCorner(coordinate, universeDimension))
             {
                 _position = Position.TopLeftCorner;
             }
             else if (IsTopRightCorner(coordinate, universeDimension))
             {
                 _position = Position.TopRightCorner;
             }
             else if (IsBottomLeftCorner(coordinate, universeDimension))
             {
                 _position = Position.BottomLeftCorner;
             }
             else if (IsBottomRightCorner(coordinate, universeDimension))
             {
                 _position = Position.BottomRightCorner;
             }

             return _position;
        }

        private bool IsTopLeftCorner(Coordinate coordinate, int universeDimension)
        {
            var topLeftCorner = new Coordinate(Constants.FirstRowOrColumn, Constants.FirstRowOrColumn);

            return coordinate.Row == topLeftCorner.Row && coordinate.Column == topLeftCorner.Column;
        }
        
        private bool IsTopRightCorner(Coordinate coordinate, int universeDimension)
        {
            var topRightCorner = new Coordinate(Constants.FirstRowOrColumn, universeDimension - Constants.ZeroIndexAdjustmentValue);

            return coordinate.Row == topRightCorner.Row && coordinate.Column == topRightCorner.Column;
        }
        
        private bool IsBottomLeftCorner(Coordinate coordinate, int universeDimension)
        {
            var bottomLeftCorner = new Coordinate(universeDimension - Constants.ZeroIndexAdjustmentValue, Constants.FirstRowOrColumn);

            return coordinate.Row == bottomLeftCorner.Row && coordinate.Column == bottomLeftCorner.Column;
        }
        
        private bool IsBottomRightCorner(Coordinate coordinate, int universeDimension)
        {
            var bottomRightCorner = new Coordinate(universeDimension - Constants.ZeroIndexAdjustmentValue, universeDimension - Constants.ZeroIndexAdjustmentValue);

            return coordinate.Row == bottomRightCorner.Row && coordinate.Column == bottomRightCorner.Column;
        }
        
        private Position GetSide(Coordinate coordinate, int universeDimension)
        {
            if (IsTopSide(coordinate, universeDimension))
            {
                _position = Position.TopSide;
            }
            else if (IsBottomSide(coordinate, universeDimension))
            {
                _position = Position.BottomSide;
            }
            else if (IsLeftSide(coordinate, universeDimension))
            {
                _position = Position.LeftSide;
            }
            else if (IsRightSide(coordinate, universeDimension))
            {
                _position = Position.RightSide;
            }

            return _position;
        }

        private bool IsTopSide(Coordinate coordinate, int universeDimension)
        {
            return coordinate.Row == Constants.FirstRowOrColumn && 
                   !IsTopLeftCorner(coordinate, universeDimension) &&
                   !IsTopRightCorner(coordinate, universeDimension);
        }

        private bool IsBottomSide(Coordinate coordinate, int universeDimension)
        {
            return coordinate.Row == universeDimension - Constants.ZeroIndexAdjustmentValue &&
                   !IsBottomLeftCorner(coordinate, universeDimension) &&
                   !IsBottomRightCorner(coordinate, universeDimension);
        }

        private bool IsLeftSide(Coordinate coordinate, int universeDimension)
        {
            return coordinate.Column == Constants.FirstRowOrColumn && 
                   !IsTopLeftCorner(coordinate, universeDimension) &&
                   !IsBottomLeftCorner(coordinate, universeDimension);
        }

        private bool IsRightSide(Coordinate coordinate, int universeDimension)
        {
            return coordinate.Column == universeDimension - Constants.ZeroIndexAdjustmentValue &&
                   !IsTopRightCorner(coordinate, universeDimension) &&
                   !IsBottomRightCorner(coordinate, universeDimension);
        }
    }
}