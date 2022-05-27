using System;

namespace ConwaysGameOfLife
{
    public static class Constants
    {
        public const string SquareCell = " \u25fc ";
        public const string Welcome = "\nWelcome to Conways Game of Life.\n\nEnter:\n'1' - to set your seed universe\n'2' - to demo the game";
        public const string Option1 = "1";
        public const string Option2 = "2";
        public const string RequestUniverseGrid = "How big would you like the universe grid size to be? Please enter a number (i.e. 3)";
        public const string UniverseGridInstructions = "Select cells you want ALIVE with keyboard arrows\nPress 'Enter' to select cell\nPress 'X' to run game";
        public const string DeadUniverse = "All cells are dead";
        
        public const ConsoleColor Alive = ConsoleColor.Green;
        public const ConsoleColor Dead = ConsoleColor.DarkBlue;
        public const ConsoleColor Terminal = ConsoleColor.Yellow;
        public const ConsoleColor Cursor = ConsoleColor.Red;
        
        public const int FirstRowOrColumn = 0;
        public const int ZeroIndexAdjustmentValue = 1;
        public const int NeighbourPositionAdjustmentValue = 1;
        
        public const int LiveNeighbourLimitForDeathByUnderpopulationLaw = 2;
        public const int LiveNeighboursLimitForDeathByOvercrowdingLaw = 3;
        public const int TwoLiveNeighboursForRemainingAlive = 2;
        public const int ThreeLiveNeighboursForRemainingAlive = 3;
    }
}