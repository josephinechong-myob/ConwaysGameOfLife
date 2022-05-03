using System;

namespace ConwaysGameOfLife
{
    public static class Constants
    {
        public const string SquareCell = " \u25fc ";
        public const ConsoleColor Alive = ConsoleColor.Cyan;
        public const ConsoleColor Dead = ConsoleColor.Magenta;
        
        
        public const int LiveNeighbourLimitForDeathByUnderpopulationLaw = 2;
        public const int LiveNeighboursLimitForDeathByOvercrowdingLaw = 3;
        public const int TwoLiveNeighboursForRemainingAlive = 2;
        public const int ThreeLiveNeighboursForRemainingAlive = 3;
        
        public const int FirstRowOrColumn = 0;
        public const int ZeroIndexAdjustmentValue = 1;

        public const int NeighbourPositionAdjustmentValue = 1;
    }
}