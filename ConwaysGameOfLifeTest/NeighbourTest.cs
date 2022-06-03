using System;
using ConwaysGameOfLife.Controller;
using ConwaysGameOfLife.Model;
using ConwaysGameOfLife.View;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest
{
    public class NeighbourTest
    {
        [Fact]
        public void Live_Top_Left_Corner_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;
            
            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Left_Corner_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;
            
            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Left_Corner_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.LeftArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }
        
        [Fact]
        public void Dead_Top_Left_Corner_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.LeftArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Right_Corner_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Right_Corner_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Right_Corner_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.LeftArrow)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }
        
        [Fact]
        public void Dead_Top_Right_Corner_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Left_Corner_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Left_Corner_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Left_Corner_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Bottom_Left_Corner_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Right_Corner_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;
            
            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Right_Corner_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Right_Corner_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Bottom_Right_Corner_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Side_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Side_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Top_Side_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Top_Side_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[0, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Side_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Side_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Bottom_Side_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Bottom_Side_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.UpArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[2, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Left_Side_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Left_Side_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Left_Side_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Left_Side_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 0];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Right_Side_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Right_Side_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Right_Side_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Right_Side_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.LeftArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 2];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Middle_Cell_Which_Has_More_Than_Three_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Middle_Cell_Which_Has_Less_Than_Two_Live_Neighbours_Should_Die()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Live_Middle_Cell_Which_Has_Two_Live_Neighbours_Should_Stay_Alive()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.DownArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }

        [Fact]
        public void Dead_Middle_Cell_Which_Has_Three_Live_Neighbours_Should_Live()
        {
            //arrange
            var mockConsole = new Mock<IGameConsole>();
            mockConsole.Setup(c => c.ReadLine()).Returns("3");
            mockConsole.SetupSequence(c => c.ReadKey())
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.RightArrow)
                .Returns(ConsoleKey.Enter)
                .Returns(ConsoleKey.X);
            var seedCreator = new SeedCreator(mockConsole.Object);
            seedCreator.MakeSeed();
            var seed = seedCreator.GetSeed();
            var universe = new Universe(mockConsole.Object, seed);
            var cell = universe.UniverseGrid[1, 1];
            var neighbour = new Neighbour(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            neighbour.SetOrientation(cell);
            var actualNumberOfLiveNeighbours = neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
            cell.State = StateLaws.UpdateState(cell.State, actualNumberOfLiveNeighbours);
            var actualCellState = cell.State;

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, actualNumberOfLiveNeighbours);
            Assert.Equal(expectedCellState, actualCellState);
        }
    }
}