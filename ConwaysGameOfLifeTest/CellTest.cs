using System;
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
        
        [Fact] 
        public void Corner_Cell_Should_Return_Position_Type_Of_Corner()
        {
            //arrange
            var coordinates = new Coordinate(1, 1);
            var universeRows = 3;
            var universeColumns = 3;
            var state = State.Alive;
            var cell = new Cell(state);
            var expectedPosition = Position.Corner;

            //act
            var actualPosition = cell.GetPositionType(coordinates, universeRows, universeColumns);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        [Fact] 
        public void Middle_Cell_Should_Return_Position_Of_Middle()
        {
            //arrange
            var coordinates = new Coordinate(2, 2);
            var universeRows = 3;
            var universeColumns = 3;
            var state = State.Alive;
            var cell = new Cell(state);
            var expectedPosition = Position.Middle;

            //act
            var actualPosition = Cell.GetType(coordinates, universeRows, universeColumns);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        /*[Fact] 
        public void Side_Cell_Should_Return_Position_Of_Side()
        {
            //arrange
            var coordinates = new Coordinate(2, 2);
            var state = State.Alive;
            var cell = new Cell(state);
            var expectedPosition = Position.Middle;

            //act
            var actualPosition = Cell.GetType(coordinates);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }*/
    }
}