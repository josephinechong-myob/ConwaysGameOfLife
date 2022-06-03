using ConwaysGameOfLife.Model;

namespace ConwaysGameOfLife.Controller
{
    public static class StateLaws
    {
        public static State UpdateState(State state, int liveNeighbours)
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