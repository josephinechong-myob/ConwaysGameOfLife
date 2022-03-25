using System;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CellTest
    {
        //happy path
        [Fact] 
        public void State_For_An_Alive_Cell_Should_Be_Alive()
        {
            //arrange
            var cell = new Cell();
            var cellState = State.Alive;

            //act
            var stateIsAlive = cell.IsAlive(cellState);

            //assert
            Assert.True(stateIsAlive);
        }
        
        //happy path
        [Fact] 
        public void State_For_A_Dead_Cell_Should_Be_Dead()
        {
            //arrange
            var cell = new Cell();
            var cellState = State.Dead;

            //act
            var stateIsAlive = cell.IsAlive(cellState);

            //assert
            Assert.False(stateIsAlive);
        }
        
        //unhappy path
    }
}