using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class UniverseTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void Universe_Width_And_Height_Should_Reflect_Initial_Seed_Specifications_For_Universe_Dimensions(int seedUniverseDimensions)
        {
            //arrange
            var universe = new Universe(seedUniverseDimensions);

            //act
            universe.CreateUniverse();
            var actualUniverseRowLength = universe.Cells.GetLength(0);
            var actualUniverseColumnLength = universe.Cells.GetLength(1);
           

            //assert
            Assert.Equal(seedUniverseDimensions, actualUniverseRowLength);
            Assert.Equal(seedUniverseDimensions, actualUniverseColumnLength);
        }
    }
}