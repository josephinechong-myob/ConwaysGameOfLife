namespace ConwaysGameOfLife
{
    public class Cell
    {
        private readonly State _state;
        public Coordinate Coordinate;
        private Position _position;

        public Cell(State state)
        {
            _state = state;
        }
        public bool IsAlive()
        { 
            return _state == State.Alive;
        }

        public Position GetPositionType(Coordinate coordinate, int universeDimension)
        {
            if (IsCorner(coordinate, universeDimension))
            {
                _position = Position.Corner;
            }
            if (IsSide(coordinate, universeDimension))
            {
                _position = Position.Side;
            }
            if (!IsCorner(coordinate, universeDimension) && !IsSide(coordinate, universeDimension))
            {
                _position = Position.Middle;
            }
            
            return _position;
        }
        
        private bool IsCorner(Coordinate coordinate, int universeDimension)
        {
            return IsTopLeftCorner(coordinate, universeDimension) || IsTopRightCorner(coordinate, universeDimension) ||
                   IsBottomLeftCorner(coordinate, universeDimension) || IsBottomRightCorner(coordinate, universeDimension);
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
        
        private bool IsSide(Coordinate coordinate, int universeDimension)
        {
            return IsTopSide(coordinate, universeDimension) || IsBottomSide(coordinate, universeDimension) ||
                   IsLeftSide(coordinate, universeDimension) || IsRightSide(coordinate, universeDimension);
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