using System;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public Coordinate Coordinate { get; }
        public PositionType.PositionType PositionType;
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