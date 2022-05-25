using System;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class GameTest
    {
        [Fact]
        public void Alive_Middle_Cell_Which_Has_No_Live_Neighbours_In_A_3_By_3_Universe_Should_Display_All_Dead_Cells_In_Next_Generation()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            var game = new Game(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 1];
            var cellSeedState = cell.State;
            var expectedCellSeedState = State.Alive;
            var expectedNumberOfLiveNeighbours = 0;
            var expectedCellState = State.Dead;

            //act
            game.UpdateUniverse(universe);
            var actualNumberOfLiveNeighbours = universe.GetLiveNeighbours(cell);
            var actualCellState = cell.State;
            /*universe.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = universe.GetLiveNeighbours(cell);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;*/

            //assert
            Assert.Equal(expectedCellSeedState, cellSeedState);
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
            Assert.Equal(ConsoleColor.Magenta, cell.Colour);
            
        }
    }
}