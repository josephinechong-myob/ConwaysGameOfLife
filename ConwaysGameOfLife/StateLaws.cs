namespace ConwaysGameOfLife
{
    public class StateLaws
    {
        public State UpdateState(State state, int liveNeighbours)
        {
            if (DeathByUnderpopulation(state, liveNeighbours))
            {
               state = State.Dead;
            }

            return state;
        }

        private bool DeathByUnderpopulation(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours < 2;
        }
    }
}