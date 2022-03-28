namespace ConwaysGameOfLife
{
    public class Cell
    {
        private readonly State _state;
        //position
        //live 
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