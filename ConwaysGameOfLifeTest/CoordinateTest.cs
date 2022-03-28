using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CoordinateTest
    {
        [Fact] 
        public void Cell_Coordinate_Should_Have_Valid_X_And_Y_Values()
        {
            //arrange
            var y_position = 3;
            var x_position = 3;
            var coordinate = new Coordinate(x_position, y_position);
            var expectedCoordinate = "3, 3";

            //act
            var actualCoordinate = Coordinate.TryParse(expectedCoordinate, out coordinate);

            //assert
            Assert.True(actualCoordinate);
        }
    }
}