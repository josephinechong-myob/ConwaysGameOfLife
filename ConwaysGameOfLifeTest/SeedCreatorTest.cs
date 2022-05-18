using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class SeedCreatorTest
    {
        private readonly Mock<IGameConsole> _mockConsole;

        public SeedCreatorTest()
        {
            _mockConsole = new Mock<IGameConsole>();
        }

        [Theory]
        [InlineData("3", 3)]
        [InlineData("6", 6)]
        [InlineData("9", 9)]
        [InlineData("15", 15)]
        [InlineData("30", 30)]

        public void Seed_Dimensions_Should_Be_A_Valid_Number(string inputValue, int expectedDimension)
        {
            //arrange
            _mockConsole.Setup(c => c.ReadLine()).Returns(inputValue);
            var seedCreator = new SeedCreator(_mockConsole.Object);

            //act
            seedCreator.SetSeedDimensions();
            var actualDimension = seedCreator.GetSeed().SeedDimensions;
            
            //assert
            Assert.Equal(expectedDimension, actualDimension);
        }

        [Theory]
        [InlineData("i", "3")]
        [InlineData(" ", "6")]
        [InlineData("}", "9")]
        [InlineData("fifteen", "15")]
        [InlineData("3T", "30")]

        public void User_Should_Be_Prompted_To_ReEnter_Value_If_Entry_For_Seed_Grid_Dimensions_Are_Invalid(
            string inputValue, string secondInputValue)
        {
            //arrange
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns(inputValue)
                .Returns(secondInputValue);
            var seedCreator = new SeedCreator(_mockConsole.Object);

            //act
            seedCreator.SetSeedDimensions();

            //assert
            _mockConsole.Verify(
                w => w.WriteLine(
                    It.Is<string>(s =>
                        s == "How big would you like the universe grid size to be? Please enter a number (i.e. 3)")
                ), Times.Exactly(2)
            );
        }
        
        [Theory, MemberData(nameof(SeedUniverseData))]
        public void User_Should_Be_Able_To_Set_Initial_Seed_Settings(string seedDimensionInput, ConsoleKey firstGridInput, ConsoleKey secondGridInput, ConsoleKey thirdGridInput, int x, int y)
        {
            //arrange
            _mockConsole.SetupSequence(c => c.ReadLine())
                .Returns(seedDimensionInput);
            _mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(firstGridInput)
                .Returns(secondGridInput)
                .Returns(thirdGridInput);
            var seedCreator = new SeedCreator(_mockConsole.Object);
            
            //act
            seedCreator.SetSeedDimensions();
            seedCreator.SetSeedCellState();
            var seed = seedCreator.GetSeed();

            //assert
            Assert.NotNull(seed);
            Assert.Equal(State.Alive, seed.SeedGrid[x,y].State);
        }
        
        public static IEnumerable<object[]> SeedUniverseData => new List<object[]>
        {
            new object[] {"3", ConsoleKey.Enter, ConsoleKey.X, ConsoleKey.X, 0, 0},
            new object[] {"4", ConsoleKey.DownArrow, ConsoleKey.Enter, ConsoleKey.X, 1, 0},
            new object[] {"3", ConsoleKey.RightArrow, ConsoleKey.Enter, ConsoleKey.X, 0, 1}
        };
    }
}