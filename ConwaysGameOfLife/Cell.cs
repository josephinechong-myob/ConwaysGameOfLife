namespace ConwaysGameOfLife
{
    public class Cell
    {
        private readonly State _state;
        public Coordinate Coordinate;
        
        public Cell(State state)
        {
            _state = state;
        }
        public bool IsAlive()
        { 
            return _state == State.Alive;
        }
    }
}