using System;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class GameTest
    {
        /*
        [Fact]
        public void Game_Should_Run_Until_All_Cells_Are_Dead()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns("6");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine("All cells are dead"), Times.Once);
        }
        
        [Fact]
        public void User_Should_Be_Prompted_Once_To_Enter_Valid_Option_If_Invalid_Value_Entered_Once()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("p")
                .Returns("2")
                .Returns("1")
                .Returns("r");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.Enter);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine(Constants.InvalidEntry), Times.Once);
        }
        [Fact]
        public void User_Should_Be_Prompted_Twice_To_Enter_Valid_Option_If_Invalid_Value_Entered_Twice()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("p")
                .Returns("2")
                .Returns("p")
                .Returns("1")
                .Returns("r");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.Enter);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine(Constants.InvalidEntry), Times.Exactly(2));
        }
        */
    }
}