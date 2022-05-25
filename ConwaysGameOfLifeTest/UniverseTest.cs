using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using ConwaysGameOfLife.Orientations;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class UniverseTest
    {
        [Theory, MemberData(nameof(SeedUniverseData))]
        public void Display_Universe_Should_Print_Universe(ConsoleKey firstGridInput, ConsoleKey secondGridInput,
            ConsoleKey thirdGridInput, State firstCellState, ConsoleColor firstCellColour, State secondCellState,
            ConsoleColor secondCellColour, State thirdCellState, ConsoleColor thirdCellColour, State fourthCellState,
            ConsoleColor fourthCellColour, State fifthCellState, ConsoleColor fifthCellColour, State sixthCellState,
            ConsoleColor sixthCellColour, State seventhCellState, ConsoleColor seventhCellColour, State eighthCellState,
            ConsoleColor eighthCellColour, State ninthCellState, ConsoleColor ninthCellColour)
        {
            //arrange
            var mockSeedConsole = new Mock<IGameConsole>();
            mockSeedConsole.SetupSequence(c => c.ReadLine())
                .Returns("3");
            mockSeedConsole.SetupSequence(c => c.ReadKey())
                .Returns(firstGridInput)
                .Returns(secondGridInput)
                .Returns(thirdGridInput);
            var seedCreator = new SeedCreator(mockSeedConsole.Object);
            seedCreator.SetSeedDimensions();
            seedCreator.SetSeedCellState();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockSeedConsole.Object, seed);

            //act
            universe.DisplayUniverse(seed.SeedGrid);

            //assert
            mockSeedConsole.Verify(c => c.Write(Constants.SquareCell), Times.Exactly(9));
            mockSeedConsole.Verify(c => c.ForegroundColor(Constants.Alive), Times.Exactly(1));
            mockSeedConsole.Verify(c => c.ForegroundColor(Constants.Dead), Times.Exactly(8));

            Assert.Equal(firstCellState, seed.SeedGrid[0, 0].State);
            Assert.Equal(firstCellColour, seed.SeedGrid[0, 0].Colour);
            Assert.Equal(secondCellState, seed.SeedGrid[0, 1].State);
            Assert.Equal(secondCellColour, seed.SeedGrid[0, 1].Colour);
            Assert.Equal(thirdCellState, seed.SeedGrid[0, 2].State);
            Assert.Equal(thirdCellColour, seed.SeedGrid[0, 2].Colour);

            Assert.Equal(fourthCellState, seed.SeedGrid[1, 0].State);
            Assert.Equal(fourthCellColour, seed.SeedGrid[1, 0].Colour);
            Assert.Equal(fifthCellState, seed.SeedGrid[1, 1].State);
            Assert.Equal(fifthCellColour, seed.SeedGrid[1, 1].Colour);
            Assert.Equal(sixthCellState, seed.SeedGrid[1, 2].State);
            Assert.Equal(sixthCellColour, seed.SeedGrid[1, 2].Colour);

            Assert.Equal(seventhCellState, seed.SeedGrid[2, 0].State);
            Assert.Equal(seventhCellColour, seed.SeedGrid[2, 0].Colour);
            Assert.Equal(eighthCellState, seed.SeedGrid[2, 1].State);
            Assert.Equal(eighthCellColour, seed.SeedGrid[2, 1].Colour);
            Assert.Equal(ninthCellState, seed.SeedGrid[2, 2].State);
            Assert.Equal(ninthCellColour, seed.SeedGrid[2, 2].Colour);
        }

        public static IEnumerable<object[]> SeedUniverseData => new List<object[]>
        {
            new object[]
            {
                ConsoleKey.Enter, ConsoleKey.X, ConsoleKey.X, State.Alive, Constants.Alive, State.Dead, Constants.Dead,
                State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead,
                Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead
            },
            new object[]
            {
                ConsoleKey.RightArrow, ConsoleKey.Enter, ConsoleKey.X, State.Dead, Constants.Dead, State.Alive,
                Constants.Alive, State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead,
                State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead,
                Constants.Dead
            },
            new object[]
            {
                ConsoleKey.DownArrow, ConsoleKey.Enter, ConsoleKey.X, State.Dead, Constants.Dead, State.Dead,
                Constants.Dead, State.Dead, Constants.Dead, State.Alive, Constants.Alive, State.Dead, Constants.Dead,
                State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead, Constants.Dead, State.Dead,
                Constants.Dead
            }
        };

        [Theory]
        [InlineData(0, 0, Orientation.TopLeftCorner)]
        [InlineData(2, 2, Orientation.BottomRightCorner)]
        [InlineData(0, 2, Orientation.TopRightCorner)]
        [InlineData(2, 0, Orientation.BottomLeftCorner)]
        public void Corner_Cell_Should_Return_Orientation_Of_Corner(int row, int column, Orientation expectedPosition)
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine())
                .Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.SetSeedDimensions();
            seedCreator.SetSeedCellState();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[row, column];
            var neighbour = new Neighbour(cell, universe._universeDimensions);

            //act
            neighbour.SetOrientation(cell);
            var actualPosition = cell.Orientation;

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }

        [Theory]
        [InlineData(1, 1, "3")]
        [InlineData(2, 2, "5")]
        [InlineData(2, 4, "9")]
        [InlineData(5, 5, "7")]
        public void Middle_Cell_Should_Return_Orientation_Of_Middle(int row, int column, string universeDimension)
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine())
                .Returns(universeDimension);
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.SetSeedDimensions();
            seedCreator.SetSeedCellState();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[row, column];
            var neighbour = new Neighbour(cell, universe._universeDimensions);

            //act
            neighbour.SetOrientation(cell);
            var actualPosition = cell.Orientation;

            //assert
            Assert.Equal(Orientation.Middle, actualPosition);
        }

        [Theory]
        [InlineData(0, 1, Orientation.TopSide)]
        [InlineData(2, 1, Orientation.BottomSide)]
        [InlineData(1, 0, Orientation.LeftSide)]
        [InlineData(1, 2, Orientation.RightSide)]
        public void Side_Cell_Should_Return_Orientation_Of_Side(int row, int column, Orientation expectedPosition)
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine())
                .Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.SetSeedDimensions();
            seedCreator.SetSeedCellState();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[row, column];
            var neighbour = new Neighbour(cell, universe._universeDimensions);

            //act
            neighbour.SetOrientation(cell);
            var actualPosition = cell.Orientation;

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
    }
}