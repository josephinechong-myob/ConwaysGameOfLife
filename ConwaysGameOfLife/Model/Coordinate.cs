using System;

namespace ConwaysGameOfLife.Model
{
    public class Coordinate
    {
        public readonly int Row;
        public readonly int Column;

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
                var row = Int32.Parse(stringCoordinate[0]); 
                var column = Int32.Parse(stringCoordinate[1]);
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