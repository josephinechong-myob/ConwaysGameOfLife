using System;

namespace ConwaysGameOfLife
{
    public class Coordinate
    {
        public int Row;
        public int Column;

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static bool TryParse(string input, out Coordinate coordinate)
        {
            try
            {
                var stringCoordinate = input.Split(',');
                var row = Int32.Parse(stringCoordinate[0]) - 1; 
                var column = Int32.Parse(stringCoordinate[1]) - 1;
                coordinate = new Coordinate(row, column);
                return true;
            }
            catch
            {
                coordinate = null;
                return false;
            }
        }
    }
}