using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
        }*/

        [Fact]
        public void New_Universe_Should_Print_Initial_Universe_Dimensions()
        {
            //arrange
            var mockSeedConsole = new Mock<IGameConsole>();
            /*mockSeedConsole.SetupSequence(c => c.ReadLine())
                .Returns("3");
            mockSeedConsole.SetupSequence(c => c.ReadKey().Key)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter);*/
            mockSeedConsole.SetupSequence(c => c.ReadLine())
                .Returns("3");
            mockSeedConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter);
            // var seed = new Seed(mockSeedConsole.Object);
            // var seedUniverseDimensions = seed.SeedDimensions;
            // var mockConsole = new Mock<IConsole>();
            // var universe = new Universe(mockConsole.Object, seedUniverseDimensions);

            //act
          //  universe.CreateUniverse();
           // universe.DisplayUniverse();
            //var cell = universe.UniverseGrid[0,0];
            
            //assert
            //mockSeedConsole.Verify(c=>c.Write(Constants.SquareCell), Times.Exactly(9));
            mockSeedConsole.Verify(c => c.ForegroundColor(Constants.Alive), Times.Exactly(1));
            //refactor using symbols to indicate colours
            
           // mockConsole.Verify(c=>c.ForegroundColor(colour) && cell);
        }
        /*[Theory, MemberData(nameof(ExpectedPrintedUniverseData))]
        public void New_Universe_Should_Print_Initial_Universe_Dimensions(int seedUniverseDimensions, int expectedTimesPrinted, string expectedPrintedUniverse, ConsoleColor colour, int colourTimes, State[,] cellsState)
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var universe = new Universe(mockConsole.Object, seedUniverseDimensions);
            mockConsole.SetupSequence(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey().Key)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter);
            var seed = new Seed(mockConsole.Object);

            //act
            universe.CreateUniverse();
            universe.DisplayUniverse();
            var cell = universe.UniverseGrid[0,0];
            
            //assert
            mockConsole.Verify(c=>c.Write(expectedPrintedUniverse), Times.Exactly(expectedTimesPrinted));
            mockConsole.Verify(c => c.ForegroundColor(colour), Times.Exactly(colourTimes));
            //refactor using symbols to indicate colours
            
            // mockConsole.Verify(c=>c.ForegroundColor(colour) && cell);
        }*/
        public static IEnumerable<object[]> ExpectedPrintedUniverseData => new List<object[]>
        {
            new object[] {
                1, 1, " \u25fc ", ConsoleColor.Cyan, 1, new State[,]
                {
                    {State.Alive}
                }
            },
            new object[] {
                1, 1, " \u25fc ", ConsoleColor.Magenta, 1, new State[,]
                {
                    {State.Dead}
                }
            },
            new object[] {
                3, 9, " \u25fc ", ConsoleColor.Cyan, 3, new State[,]
                {
                    {State.Dead, State.Dead, State.Dead}, 
                    {State.Alive, State.Alive, State.Dead},
                    {State.Dead, State.Dead, State.Alive}
                }
            },
            new object[] {
                4, 16, " \u25fc ", ConsoleColor.Cyan, 9, new State[,]
                {
                    {State.Alive, State.Dead, State.Dead, State.Alive}, 
                    {State.Alive, State.Alive, State.Dead, State.Alive},
                    {State.Dead, State.Dead, State.Alive, State.Alive},
                    {State.Dead, State.Dead, State.Alive, State.Alive}
                }
            },
            new object[] {
                5, 25, " \u25fc ", ConsoleColor.Cyan, 16, new State[,]
                {
                    {State.Alive, State.Dead, State.Dead, State.Alive, State.Alive}, 
                    {State.Alive, State.Alive, State.Dead, State.Alive, State.Alive},
                    {State.Dead, State.Dead, State.Alive, State.Alive, State.Alive},
                    {State.Dead, State.Dead, State.Alive, State.Alive, State.Alive},
                    {State.Dead, State.Dead, State.Alive, State.Alive, State.Alive},
                }
            }
            
            /*new object[] {3, new[,] {{" \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc "}}},
            new object[] {4, new[,] {{" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}}},
            new object[] {5, new[,] {{" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}, {" \u25fc ", " \u25fc ", " \u25fc ", " \u25fc ", " \u25fc "}}}*/
            
            //order of what console colour is printed
        };
    }
}