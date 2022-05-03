using System.Collections.Generic;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class SeedTest
    {
        private readonly Mock<IConsole> _mockConsole;
        
        public SeedTest()
        {
            _mockConsole = new Mock<IConsole>();
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
            var seed = new Seed(_mockConsole.Object);

            //act
            var actualDimension = seed.SeedDimensions;

            //assert
            Assert.Equal(expectedDimension, actualDimension);
        }
        
        [Theory] 
        [InlineData("i", "3")]
        [InlineData(" ", "6")]
        [InlineData("}", "9")]
        [InlineData("fifteen", "15")]
        [InlineData("3T", "30")]
        
        public void User_Should_Be_Prompted_To_ReEnter_Value_If_Entry_For_Seed_Grid_Dimensions_Are_Invalid(string inputValue, string secondInputValue)
        {
            //arrange
            _mockConsole.SetupSequence(r => r.ReadLine())
                .Returns(inputValue)
                .Returns(secondInputValue);
            
            //act
            var unused = new Seed(_mockConsole.Object);
            
            //assert
            _mockConsole.Verify(
               w => w.WriteLine(
                   It.Is<string>(s => s == "How big would you like the universe grid size to be? Please enter a number (i.e. 3)")
               ), Times.Exactly(2)
           );
       }
        
        /*[Theory, MemberData(nameof(seedUniverseData))]
        public void User_Should_Be_Able_To_Set_Initial_Seed_Settings(string seedDimensionInput, string[,] seedUniverseSetting)
        {
            //arrange
            _mockConsole.SetupSequence(r => r.ReadLine())
                .Returns(seedDimensionInput)
                .Returns(seedUniverseSetting);
            var seed = new Seed(_mockConsole.Object);
            
            //act
            var actualSeedSettings = seed.SeedUniverseSettings;
            
            //assert
            Assert.Equal(seedUniverseSetting, actualSeedSettings);
            /*_mockConsole.Verify(
                w => w.WriteLine(
                    It.Is<string>(s => s == initalPrintedUniverse)
                ), Times.Exactly(2)
            );#1#
        }
        
        public static IEnumerable<object[]> seedUniverseData => new List<object[]>
        {
            new object[] {"3", new[,] {{" . ", " . ", " . "}, {" . ", " . ", " . "}, {" . ", " . ", " . "}}}
           // new object[] {4, new[,] {{" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . "}}},
            //new object[] {5, new[,] {{" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}, {" . ", " . ", " . ", " . ", " . "}}}
        };*/
    }
}