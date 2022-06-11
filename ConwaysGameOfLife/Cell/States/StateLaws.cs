namespace ConwaysGameOfLife.States
{
    public static class StateLaws //use the state of the cells some how
    {
        public static State GetNextState(State state, int liveNeighbours)
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
        
        private static bool IsDeadByUnderpopulation(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours < Constants.LiveNeighbourLimitForDeathByUnderpopulationLaw;
        }

        private static bool IsDeadByOvercrowding(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours > Constants.LiveNeighboursLimitForDeathByOvercrowdingLaw;
        }

        private static bool IsAlive(State state, int liveNeighbours)
        {
            return state == State.Alive && liveNeighbours == Constants.TwoLiveNeighboursForRemainingAlive || 
                   state == State.Alive && liveNeighbours == Constants.ThreeLiveNeighboursForRemainingAlive ||
                   state == State.Dead && liveNeighbours == Constants.ThreeLiveNeighboursForRemainingAlive;
        }
    }
}