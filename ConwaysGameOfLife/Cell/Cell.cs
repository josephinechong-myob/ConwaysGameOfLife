using System;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public readonly Coordinate Coordinate;
        internal PositionType.PositionType PositionType;
        public readonly string Symbol;
        public ConsoleColor Colour => State == State.Alive ? Constants.Alive : Constants.Dead;
        public State State;

        public Cell(Coordinate coordinate, State state)
        {
            Coordinate = coordinate;
            State = state;
            Symbol = Constants.SquareCell;
        }

        public PositionType.PositionType GetPositionType()
        {
            return PositionType;
        }
    }
}