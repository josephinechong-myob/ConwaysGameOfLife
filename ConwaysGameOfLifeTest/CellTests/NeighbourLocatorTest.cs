using System;
using ConwaysGameOfLife;
using ConwaysGameOfLife.Console;
using ConwaysGameOfLife.Seed;
using ConwaysGameOfLife.States;
using Moq;
using Xunit;

namespace ConwaysGameOfLifeTest.CellTests
{
    public class NeighbourLocatorTest
    {
        private int GetActualNumberOfLiveNeighbours(NeighbourLocator neighbour, Cell cell, Universe universe)
        {
            neighbour.SetOrientation(cell);
            return neighbour.GetLiveNeighbours(cell, universe.UniverseGrid, universe.UniverseDimensions);
        }
        
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;
            
            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;
            
            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            
            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 4;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 1;
            var expectedCellState = State.Dead;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 2;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
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
            var neighbour = new NeighbourLocator(cell, universe.UniverseDimensions);
            var expectedNumberOfLiveNeighbours = 3;
            var expectedCellState = State.Alive;

            //act
            cell.State = StateLaws.GetNextState(cell.State, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));

            //assert
            Assert.Equal(expectedNumberOfLiveNeighbours, GetActualNumberOfLiveNeighbours(neighbour, cell, universe));
            Assert.Equal(expectedCellState, cell.State);
        }
    }
}