using System;
using System.Drawing;
using ConwaysGameOfLife.Orientations;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public Coordinate Coordinate { get; }
        public Orientation Orientation;
        public string Symbol { get; }
        public ConsoleColor Colour { get; set; }
        public State State;

        public Cell(Coordinate coordinate, State state)
        {
            Coordinate = coordinate;
            State = state;
            UpdateColour(state);
            //Colour = state == State.Alive ? Constants.Alive : Constants.Dead;
            Symbol = Constants.SquareCell;
        }

        public void UpdateColour(State state)
        {
            Colour = state == State.Alive ? Constants.Alive : Constants.Dead;
        }
    }
}