namespace ConwaysGameOfLife
{
    public class StateLaws
    {
        public State UpdateState(State state, int liveNeighbours)
        {
            if (IsAlive(state, liveNeighbours))
            {
                state = State.Alive;
            }
            else if (IsDeadByUnderpopulation(state, liveNeighbours) || IsDeadByOvercrowding(state, liveNeighbours))
            {
               state = State.Dead;
            }
            return state;
        }

        private bool IsDeadByUnderpopulation(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours < Constants.LiveNeighbourLimitForDeathByUnderpopulationLaw;
        }

        private bool IsDeadByOvercrowding(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours > Constants.LiveNeighboursLimitForDeathByOvercrowdingLaw;
        }

        private bool IsAlive(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours == Constants.TwoLiveNeighboursForRemainingAlive || 
                   state == State.Alive && liveNeighbours == Constants.ThreeLiveNeighboursForRemainingAlive ||
                   state == State.Dead && liveNeighbours == Constants.ThreeLiveNeighboursForRemainingAlive;
        }
    }
}