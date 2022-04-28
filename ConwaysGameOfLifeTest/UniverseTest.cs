using System.Collections.Generic;
using ConwaysGameOfLife;
using Moq;
using Xunit;


namespace ConwaysGameOfLifeTest
{
    public class UniverseTest
    {
        /*private Mock<IConsole> _mockConsole;
        public UniverseTest()
        {
            _mockConsole = new Mock<IConsole>();
        }
        
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
        
        [Theory, MemberData(nameof(expectedPrintedUniverseData))]
        public void New_Universe_Should_Print_Initial_Universe_Dimensions(int seedUniverseDimensions, string [,] expectedPrintedUniverse)
        {
            //arrange
            var universe = new Universe(seedUniverseDimensions);

            //act
            universe.CreateUniverse();
            universe.DisplayUniverse();
            var actualPrintedUniverse = universe.Cells;
            
            //assert
            Assert.Equal(expectedPrintedUniverse, actualPrintedUniverse);
        }
        public static IEnumerable<object[]> expectedPrintedUniverseData => new List<object[]>
        {
            new object[] {3, new[,] {{" . ", " . ", " . "}, {" . ", " . ", " . "}, {" . ", " . ", " . "}}},
            new object[] {4, new[,] {{" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}}},
            new object[] {5, new[,] {{" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}}}
        };*/

        /*[Theory, MemberData(nameof(expectedPrintedUniverseData))]
        public void New_Universe_Should_Print_Initial_Universe_Dimensions(int seedUniverseDimensions, string [,] expectedPrintedUniverse)
        {
            //arrange
            var universe = new Universe(seedUniverseDimensions);

            //act
            universe.CreateUniverse();
            universe.DisplayUniverse();
            var actualPrintedUniverse = universe.Cells;
            
            //assert
            Assert.Equal(expectedPrintedUniverse, actualPrintedUniverse);
        }
        public static IEnumerable<object[]> expectedPrintedUniverseData => new List<object[]>
        {
            new object[] {3, new[,] {{" \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc "}}},
            new object[] {4, new[,] {{" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}}},
            new object[] {5, new[,] {{" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}}}
        };*/
        
        /*[Fact]
        public void Universe_Should_Be_Updated_To_Reflect_Changes_To_Cell_State()
        {
            //arrange
            var seed = 3;
            var universe = new Universe(seed);
            var expectedUpdatedUniverse = new[,]
            {
                {" 1 ", " . ", " 1 "}, 
                {" . ", " . ", " . "},
                {" . ", " . ", " . "}
            };

            //act
            universe.CreateUniverse();
            universe.DisplayUniverse();
            var actualPrintedUniverse = universe.Cells;
            
            //assert
            Assert.Equal(expectedUpdatedUniverse, actualPrintedUniverse);
        }*/
    }
}