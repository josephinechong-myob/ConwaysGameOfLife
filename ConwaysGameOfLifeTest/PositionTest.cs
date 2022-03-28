using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class PositionTest
    {
        [Fact] 
        public void Middle_Cell_Should_Return_Position_Of_Middle()
        {
            //arrange
            var coordinates = new Coordinate(2, 2);
            var positon = new Positon();
            var expectedPosition = Position.Middle;

            //act
            var actualPosition = Position.GetType(coordinates);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
    }
}