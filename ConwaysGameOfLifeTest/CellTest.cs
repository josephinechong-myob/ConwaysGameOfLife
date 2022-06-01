using System;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CellTest
    {
        [Theory] 
        [InlineData(State.Alive, Constants.Alive)]
        [InlineData(State.Dead, Constants.Dead)]
        public void Console_Colour_For_An_Cell_Should_Match_Its_Assigned_State(State cellState, ConsoleColor expectedColour)
        {
            //arrange
            var coordinate = new Coordinate(0, 0);
            var cell = new Cell(coordinate, cellState);

            //act
            var actualColour = cell.Colour;

            //assert
            Assert.Equal(expectedColour, actualColour);
        }
    }
}