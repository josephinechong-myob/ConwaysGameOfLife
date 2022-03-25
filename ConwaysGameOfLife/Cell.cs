namespace ConwaysGameOfLife
{
    public class Cell
    {
        private State State { get; set; }
        
        public bool IsAlive(State state)
        {
            return state == State.Alive;
        }
    }
}