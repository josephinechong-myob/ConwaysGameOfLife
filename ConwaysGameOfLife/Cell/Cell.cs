using System;
using ConwaysGameOfLife.States;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        private Coordinate Coordinate { get; }
        internal PositionType.PositionType PositionType;
        private string Symbol { get; }
        private ConsoleColor Colour => State == State.Alive ? Constants.Alive : Constants.Dead;
        public State State;

        public Cell(Coordinate coordinate, State state)
        {
            Coordinate = coordinate;
            State = state;
            Symbol = Constants.SquareCell;
        }

        public Coordinate GetCoordinate()
        {
            return Coordinate;
        }

        public PositionType.PositionType GetPositionType()
        {
            return PositionType;
        }

        public string GetSymbol()
        {
            return Symbol;
        }

        public ConsoleColor GetColour()
        {
            return Colour;
        }
    }
}