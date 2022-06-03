using System;
using ConwaysGameOfLife.Controller;
using ConwaysGameOfLife.Model;
using ConwaysGameOfLife.View;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class GameTest
    {
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
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal, "All cells are dead"), Times.Once);
        }
        
        [Fact]
        public void User_Should_Be_Prompted_Once_To_Enter_Valid_Option_If_Invalid_Value_Entered_Once()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("p")
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
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal,Constants.InvalidEntry), Times.Once);
        }
        
        [Fact]
        public void User_Should_Be_Prompted_Twice_To_Enter_Valid_Option_If_Invalid_Value_Entered_Twice()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("p")
                .Returns("p")
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
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal, Constants.InvalidEntry), Times.Exactly(2));
        }
        
        [Fact]
        public void User_Should_Be_Able_To_Run_Demo_Option1()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("2")
                .Returns("1");
            mockConsole.SetupSequence(c => c.KeyAvailable())
                .Returns(true);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal, "Running demo"), Times.Exactly(1));
        }
        
        [Fact]
        public void User_Should_Be_Prompted_To_Enter_Valid_Option_If_Invalid_Value_Entered_To_Run_Demo()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("2")
                .Returns("p")
                .Returns("2");
            mockConsole.SetupSequence(c => c.KeyAvailable())
                .Returns(true);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal,Constants.InvalidEntry), Times.Once);
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal, Constants.Demo), Times.Exactly(1));
        }
        [Fact]
        public void User_Should_Be_Prompted_Three_Times_To_Enter_Valid_Option_If_Invalid_Value_Entered_Three_Times()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.SetupSequence(c => c.ReadLine())
                .Returns("p")
                .Returns("p")
                .Returns("2")
                .Returns("p")
                .Returns("2");
            mockConsole.SetupSequence(c => c.KeyAvailable())
                .Returns(true);
            var game = new Game(mockConsole.Object);

            //act
            game.Options();
            
            //assert
            mockConsole.Verify(c => c.WriteLine(Constants.Terminal, Constants.InvalidEntry), Times.Exactly(3));
        }
    }
}