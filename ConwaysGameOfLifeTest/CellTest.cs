using System;
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

            //act
            var stateIsAlive = cell.IsAlive();

            //assert
            Assert.True(stateIsAlive);
        }
        
        //happy path
        /*[Fact] 
        public void State_For_A_Dead_Cell_Should_Be_Dead()
        {
            //arrange
            var cell = new Cell();

            //act
            var stateIsAlive = cell.IsAlive();

            //assert
            Assert.False(stateIsAlive);
        }*/
        
        //unhappy path
    }
}