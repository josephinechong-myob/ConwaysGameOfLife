using System;
using System.IO;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class GameConsoleTest
    {
        [Fact]
        public void Foreground_Colour_Should_Display_Console_Colour_When_Used()
        {
            //arrange
            var gameConsole = new GameConsole();
            var expectedColour = Constants.Alive;

            //act
            gameConsole.ForegroundColor(Constants.Alive);
            var actualColour = Console.ForegroundColor;

            //assert
            Assert.Equal(expectedColour, actualColour);
        }
        
        [Fact]
        public void Game_Console_Write_Should_Write_To_Console()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var gameConsole = new GameConsole();
            var expectedText = "hello";

            //act
            gameConsole.Write("hello");

            //assert
            Assert.Equal(expectedText, stringWriter.ToString());
        }
        
        [Fact]
        public void Game_Console_WriteLine_Should_Write_On_A_New_Line_To_Console()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var gameConsole = new GameConsole();
            var expectedText = "hello\n";

            //act
            gameConsole.WriteLine("hello");

            //assert
            Assert.Equal(expectedText, stringWriter.ToString());
        }
        
        [Fact]
        public void Game_Console_ReadLine_Should_Be_Read_By_Console()
        {
            //arrange
            var stringReader = new StringReader("hello world");
            Console.SetIn(stringReader);
            var gameConsole = new GameConsole();
            var expectedLine = "hello world";

            //act
            var actualLine = gameConsole.ReadLine();

            //assert
            Assert.Equal(expectedLine, actualLine);
        }
        
        //NOT SURE HOW TO TEST READKEY.KEY
        /*[Fact]
        public void Game_Console_ReadKey_Should_Be_Console_Key_Read_By_Console()
        {
            //arrange
            var gameConsole = new GameConsole();

            //act
            var expected = gameConsole.ReadKey();
            var actualKey = Console.ReadKey().Key;

            //assert
            Assert.Equal(expected, actualKey);
        }*/
    }
}