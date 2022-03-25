using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class StateLawsTest
    {
        [Fact]
        public void Cell_State_Should_Change_From_Alive_To_Dead_If_Alive_Cell_Has_Less_Than_Two_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Alive;
            var stateLaw = new StateLaws();
            var numberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            var updatedCellState = stateLaw.UpdateState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }
        
        [Fact]
        public void Cell_State_Should_Change_To_Dead_If_Alive_Cell_Has_Greater_Than_Three_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Alive;
            var stateLaw = new StateLaws();
            var numberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            var updatedCellState = stateLaw.UpdateState(originalCellState, numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }
        
        /*[Fact] //change to theory
        public void Cell_State_Should_Stay_Alive_If_Alive_Cell_Has_Two_Or_Three_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Alive;
            var stateLaw = new StateLaws();
            var numberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            var updatedCellState = stateLaw.UpdateCellState(numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }

        [Fact]
        public void Cell_State_Should_Change_From_Dead_To_Alive_If_Dead_Cell_Has_Less_Three_Live_Neighbours()
        {
            //arrange
            var originalCellState = State.Dead;
            var stateLaw = new StateLaws();
            var numberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            var updatedCellState = stateLaw.UpdateCellState(numberOfLiveNeighbours);
            
            //assert
            Assert.Equal(expectedCellState, updatedCellState);
        }*/
    }
}