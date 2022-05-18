using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class SeedBuilderTest
    {
        private readonly Mock<IGameConsole> _mockConsole;

        public SeedBuilderTest()
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
            _mockConsole.Setup(r => r.ReadLine()).Returns(inputValue);
            Cell[,] cellState = new Cell [expectedDimension, expectedDimension];
            //var seed = new Seed(_mockConsole.Object);
            var seedBuilder = new SeedBuilder(_mockConsole.Object);

            //act
            seedBuilder.SetSeedDimensions();
            var actualDimension = seedBuilder.GetSeed().SeedDimensions;
            
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
            _mockConsole.SetupSequence(r => r.ReadLine())
                .Returns(inputValue)
                .Returns(secondInputValue);
            /*var seed = new Seed(_mockConsole.Object);*/
            
            //act
            //seed.SetSeedDimensions();
            
            var seedBuilder = new SeedBuilder(_mockConsole.Object);

            //act
            seedBuilder.SetSeedDimensions();

            //assert
            _mockConsole.Verify(
                w => w.WriteLine(
                    It.Is<string>(s =>
                        s == "How big would you like the universe grid size to be? Please enter a number (i.e. 3)")
                ), Times.Exactly(2)
            );
        }
        
        [Theory, MemberData(nameof(SeedUniverseData))]
        public void User_Should_Be_Able_To_Set_Initial_Seed_Settings(string seedDimensionInput)
        {
            //arrange
            _mockConsole.SetupSequence(r => r.ReadLine())
                .Returns(seedDimensionInput);
            _mockConsole.SetupSequence(r => r.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            //var seed = new Seed(_mockConsole.Object);
            var seedbuilder = new SeedBuilder(_mockConsole.Object);
            
            //act
            seedbuilder.SetSeedDimensions();
            seedbuilder.SetSeedCellState();
            var seed = seedbuilder.GetSeed();
            /*seed.SetSeedDimensions();
            seed.SetSeedCellState();*/
            
            //assert
            Assert.NotNull(seed);
            Assert.Equal(State.Alive, seed.SeedGrid[0,0].State);
        }
        
        public static IEnumerable<object[]> SeedUniverseData => new List<object[]>
        {
            new object[] {"3"}
            //new object[] {"3", new[,] {{" . ", " . ", " . "}, {" . ", " . ", " . "}, {" . ", " . ", " . "}}}
           // new object[] {4, new[,] {{" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}}},
            //new object[] {5, new[,] {{" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}}}
        };
    }

        /*[Theory, MemberData(nameof(seedUniverseData))]
        public void User_Should_Be_Able_To_Set_Initial_Seed_Settings(string seedDimensionInput, string userStateInput, State[,] seedCellsState)
        {
            //arrange
            _mockConsole.SetupSequence(r => r.ReadLine())
                .Returns(seedDimensionInput)
                .Returns(userStateInput);
            var seed = new Seed(_mockConsole.Object);
            
            //act
            var actualSeedSettings = seed.SeedCellState;
            
            //assert
            Assert.Equal(seedCellsState, actualSeedSettings);
            /*_mockConsole.Verify(
                w => w.WriteLine(
                    It.Is<string>(s => s == initalPrintedUniverse)
                ), Times.Exactly(2)
            );#1#
        }
        
        public static IEnumerable<object[]> seedUniverseData => new List<object[]>
        {
            new object[] {3, "Alive", new State[,]
            {
                {State.Alive, State.Dead, State.Dead}, 
                {State.Alive, State.Alive, State.Dead},
                {State.Dead, State.Dead, State.Alive}
            }}
            //new object[] {"3", new[,] {{" . ", " . ", " . "}, {" . ", " . ", " . "}, {" . ", " . ", " . "}}}
           // new object[] {4, new[,] {{" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}}},
            //new object[] {5, new[,] {{" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}}}
        };
    }*/
    
}