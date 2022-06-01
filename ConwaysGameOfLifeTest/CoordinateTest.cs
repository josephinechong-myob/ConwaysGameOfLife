using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CoordinateTest
    {
        [Theory]
        [InlineData("1, 1", 1, 1)]
        [InlineData("3, 3", 3, 3)]
        [InlineData("9, 9", 9, 9)]
        public void Try_Parse_Should_Return_True_If_Input_For_Coordinate_Is_Valid(string input, int xPosition, int yPosition)
        {
            //arrange
            Coordinate coordinate = new Coordinate(xPosition, yPosition);
            var expectedCoordinate = new Coordinate(xPosition, yPosition);

            //act
            var actualCoordinate = Coordinate.TryParse(input, out coordinate);

            //assert
            Assert.True(actualCoordinate);
            Assert.Equal(expectedCoordinate.Column, coordinate.Column);
            Assert.Equal(expectedCoordinate.Row, coordinate.Row);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("@")]
        [InlineData("1, a")]
        [InlineData("a, b")]
        public void Try_Parse_Should_Return_False_If_Input_For_Coordinate_Is_Invalid(string input)
        {
            //arrange
            Coordinate coordinate = null;

            //act
            var actualCoordinate = Coordinate.TryParse(input, out coordinate);

            //assert
            Assert.False(actualCoordinate);
        }
    }
}