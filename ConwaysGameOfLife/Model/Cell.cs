using System;
using ConwaysGameOfLife.Orientations;

namespace ConwaysGameOfLife.Model
{
    public class Cell
    {
        public Coordinate Coordinate { get; }
        public Orientation Orientation;
        public string Symbol { get; }
        public ConsoleColor Colour => State == State.Alive ? Constants.Alive : Constants.Dead;
        public State State;

        public Cell(Coordinate coordinate, State state)
        {
            Coordinate = coordinate;
            State = state;
            Symbol = Constants.SquareCell;
        }
    }
}