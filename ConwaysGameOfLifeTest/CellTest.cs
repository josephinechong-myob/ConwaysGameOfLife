using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class CellTest
    {
        [Theory] 
        [InlineData(State.Alive, Constants.Alive)]
        [InlineData(State.Dead, Constants.Dead)]
        public void Console_Colour_For_An_Cell_Should_Match_Its_Assigned_State(State cellState, ConsoleColor expectedColour)
        {
            //arrange
            var coordinate = new Coordinate(0, 0);
            var cell = new Cell(coordinate, cellState);

            //act
            var actualColour = cell.Colour;

            //assert
            Assert.Equal(expectedColour, actualColour);
        }
        
        /*[Theory]
        [InlineData(0, 0, Orientation.TopLeftCorner)]
        [InlineData(2, 2, Orientation.BottomRightCorner)]
        [InlineData(0, 2, Orientation.TopRightCorner)]
        [InlineData(2, 0, Orientation.BottomLeftCorner)]
        public void Corner_Cell_Should_Return_Orientation_Of_Corner(int row, int column, Orientation expectedPosition)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var universeDimension = 3;
            var state = State.Alive;
            var cell = new Cell(coordinate, state);

            //act
            var actualPosition = cell.GetOrientation(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }*/
        
        /*[Theory]
        [InlineData(1, 1, 3)]
        [InlineData(2, 2, 5)] 
        [InlineData(2, 4, 9)]
        [InlineData(5, 5, 7)]
        public void Middle_Cell_Should_Return_Orientation_Of_Middle(int row, int column, int universeDimension)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var state = State.Alive;
            var cell = new Cell(coordinate, state);
            var expectedPosition = Orientation.Middle;

            //act
            var actualPosition = cell.GetOrientation(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        
        [Theory]
        [InlineData(0, 1, Orientation.TopSide)]
        [InlineData(2, 1, Orientation.BottomSide)] 
        [InlineData(1, 0, Orientation.LeftSide)]
        [InlineData(1, 2, Orientation.RightSide)]
        public void Side_Cell_Should_Return_Orientation_Of_Side(int row, int column, Orientation expectedPosition)
        {
            //arrange
            var coordinate = new Coordinate(row, column);
            var universeDimension = 3;
            var state = State.Alive;
            var cell = new Cell(coordinate, state);

            //act
            var actualPosition = cell.GetOrientation(coordinate, universeDimension);

            //assert
            Assert.Equal(expectedPosition, actualPosition);
        }
        //seed > universe > cell > state
        
        [Fact] 
        public void Alive_Cell_Who_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var cellState = State.Alive;
            var coordinate = new Coordinate(0, 0);
            var cell = new Cell(coordinate, cellState);
            List<Coordinate> neighbourCoordinates;
            
            var expectedNumberOfLiveNeighbours = 2;
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var universeDimension = universe.UniverseGrid.Length;
            var coordinate = universe.UniverseGrid[0].Coordinate;
            
            //act
            var actualNumberOfLiveNeighbours = cell.GetLiveNeighbours(universeDimension, universe);

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
        }*/
    }
}