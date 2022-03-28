namespace ConwaysGameOfLife
{
    public class Cell
    {
        private readonly State _state;
        public Coordinate Coordinate;
        private Position position;
        
        public Cell(State state)
        {
            _state = state;
        }
        public bool IsAlive()
        { 
            return _state == State.Alive;
        }

        public Position GetPositionType(Coordinate coordinate, int universeRows, int universeColumns)
        {
            if (IsCorner(coordinate, universeRows, universeColumns))
            {
                var position = Position.Corner;
            }

            return position;
        }

        private bool IsCorner(Coordinate coordinate, int universeRows, int universeColumns)
        {
            var topLeftCorner = new Coordinate(0,0);
            var topRightCorner = new Coordinate(0, universeColumns-1);
            var bottomLeftCorner = new Coordinate(universeRows - 1, 0);
            var bottomRightCorner = new Coordinate(universeRows - 1, universeColumns - 1);
            
            return coordinate == topLeftCorner || coordinate == topRightCorner || coordinate == bottomLeftCorner || coordinate == bottomRightCorner;
        }

        /*private bool IsMiddle()
        {
            //cell is not corner or side
        }

        private bool IsSide()
        {
            // FR (not FC || LC) || LR (not FC || LC) || FC (not FR || LR) || LC (not FR || LR)
        }*/
    }
}