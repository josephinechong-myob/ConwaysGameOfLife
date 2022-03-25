namespace ConwaysGameOfLife
{
    public class Cell
    {
        public State State;

        public bool IsAlive(State state)
        {
            return state == State.Alive;
        }
    }
}