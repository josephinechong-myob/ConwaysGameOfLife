using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class Universe
    {
        [Fact]
        public void Universe_Width_And_Height_Should_Reflect_Initial_Seed_Specifications_For_Universe_Dimensions()
        {
            //arrange
            var seedUniverseDimensions = 3;
            var universe = new Universe();

            //act
            var excepctedUniverseColumnLength = 3;
            var expectedUniverseRowLength = 3;
            var actualUniverseColumnLength = universe.Column.count;
            var actualUniverseRowLength = universe.Row.count;

            //assert
            Assert.Equal(expectedUniverseRowLength, actualUniverseRowLength);
            Assert.Equal(excepctedUniverseColumnLength, actualUniverseColumnLength);
        }
    }
}