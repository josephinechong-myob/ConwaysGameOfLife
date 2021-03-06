using ConwaysGameOfLife.States;
using Xunit;

namespace ConwaysGameOfLifeTest.CellTests.StateTests
{
    public class StateLawsTest
    {
        [Fact]
        public void Cell_State_Should_Change_From_Alive_To_Dead_If_Alive_Cell_Has_Less_Than_Two_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Alive;
            var numberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            var updatedCellState = StateLaws.GetNextState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }
        
        [Fact]
        public void Cell_State_Should_Change_To_Dead_If_Alive_Cell_Has_Greater_Than_Three_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Alive;
            var numberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            var updatedCellState = StateLaws.GetNextState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Cell_State_Should_Stay_Alive_If_Alive_Cell_Has_Two_Or_Three_Live_Neighbours(int numberOfLiveNeighbours)
        {
            //arrange
            var originalCellState = State.Alive;
            var expectedCellState = State.Alive;

            //act
            var updatedCellState = StateLaws.GetNextState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }

        [Fact]
        public void Cell_State_Should_Change_From_Dead_To_Alive_If_Dead_Cell_Has_Three_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Dead;
            var numberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            var updatedCellState = StateLaws.GetNextState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }
    }
}