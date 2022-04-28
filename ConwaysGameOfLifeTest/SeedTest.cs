using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class SeedTest
    {
        private Mock<IConsole> _mockConsole;
        
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
            var actualDimension = seed.seedDimensions;

            //assert
            Assert.Equal(expectedDimension, actualDimension);
        }
        
        [Theory] 
        [InlineData("i", "3")]
        [InlineData("a", "6")]
        [InlineData("b", "9")]
        [InlineData("c", "15")]
        [InlineData("d", "30")]
        
        public void Seed_Dimensions_Should_Be_A_Valid_Number_b(string inputValue, string secondInputValue)
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
    }
}