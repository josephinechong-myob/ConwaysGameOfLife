using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CellTest
    {
        [Fact] 
        public void State_For_An_Alive_Cell_Should_Be_Alive()
        {
            //arrange
            var cellState = State.Alive;
            var cell = new Cell(cellState);

            //act
            var stateIsAlive = cell.IsAlive();

            //assert
            Assert.True(stateIsAlive);
        }
        
        [Fact] 
        public void State_For_A_Dead_Cell_Should_Be_Dead()
        {
            //arrange
            var cellState = State.Dead;
            var cell = new Cell(cellState);

            //act
            var stateIsAlive = cell.IsAlive();

            //assert
            Assert.False(stateIsAlive);
        }
        
        [Theory]
        [InlineData(0, 0, Position.TopLeftCorner)]
        [InlineData(2, 2, Position.BottomRightCorner)]
        [InlineData(0, 2, Position.TopRightCorner)]
        [InlineData(2, 0, Position.BottomLeftCorner)]
        public void Corner_Cell_Should_Return_Position_Type_Of_Corner(int row, int column, Position expectedPosition)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var universeDimension = 3;
            var state = State.Alive;
            var cell = new Cell(state);

            //act
            var actualPosition = cell.GetPosition(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(2, 2, 5)] 
        [InlineData(2, 4, 9)]
        [InlineData(5, 5, 7)]
        public void Middle_Cell_Should_Return_Position_Of_Middle(int row, int column, int universeDimension)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var state = State.Alive;
            var cell = new Cell(state);
            var expectedPosition = Position.Middle;

            //act
            var actualPosition = cell.GetPosition(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        [Theory]
        [InlineData(0, 1, Position.TopSide)]
        [InlineData(2, 1, Position.BottomSide)] 
        [InlineData(1, 0, Position.LeftSide)]
        [InlineData(1, 2, Position.RightSide)]
        public void Side_Cell_Should_Return_Position_Of_Side(int row, int column, Position expectedPosition)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var universeDimension = 3;
            var state = State.Alive;
            var cell = new Cell(state);

            //act
            var actualPosition = cell.GetPosition(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        /*[Fact] 
        public void Two_Live_Neighbours_Should_Return_Two_Live_Neighbours()
        {
            //arrange
            var cellState = State.Alive;
            var cell = new Cell(cellState);
            var expectedNumberOfLiveNeighbours = 2;
            var cellPosition = Position.Middle;
            var coordinate = new Coordinate(1, 1);
            var universeDimension = 3;

            //act
            var actualNumberOfLiveNeighbours = cell.GetLiveNeighbours();

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
        }*/
        
    }
}