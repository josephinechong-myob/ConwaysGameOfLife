# Conway's Game Of Life

This Conway's Game of Life game has been developed in C# for this [kata](https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-conways-game-of-life/kata-conways-game-of-life.md). 

## Game objective

This game is a simulation of life, based from the player's inital setting of grid (i.e. 'world') size and initial state.

The universe of the Game of Life is a two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. Every cell interacts with its eight neighbors, which are the cells that are directly horizontally, vertically, or diagonally adjacent.

At each step in time, the following transitions occur:

- Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any dead cell with exactly three live neighbours becomes a live cell.

The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed. Births and deaths happen simultaneously, and the discrete moment at which this happens is sometimes called a tick. The rules continue to be applied repeatedly to create further generations.

## Run & Build Notes
You need to be able to read the code on an IDE that can compile C# (i.e. Rider). The game is displayed on the terminal.

## Coding principles used:
- TDD (Test driven development)
- Good testing code coverage
- Test doubles
- Interfaces
- Inline testing & Facts (Unit tests)
- Constructor methods & public fields 
- Single responsibility principle (SRP) to write functions
- DRY principle (do not repeat yourself)
- Readability for functions and their names

## Game design (WIP)

![UML diagram](https://github.com/josephinechong-myob/ConwaysGameOfLife/blob/main/ConwaysGameOfLife.drawio-2.png)
