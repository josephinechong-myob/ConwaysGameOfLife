namespace ConwaysGameOfLife
{
    public class Cell
    {
        private State State { get; set; }
        //position
        //live 
        
        public bool IsAlive(State state) //don't want to pass in the state
        { 
            return state == State.Alive;
        }
    }
}