using System;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        public string [,] Cells { get;}

        public Universe(int seedDimensions)
        {
            var dimensions = seedDimensions;
            Cells = new string[dimensions, dimensions];
        }
        
        public void CreateUniverse()
        {
            var width = Cells.GetUpperBound(0) + 1;
            var height = Cells.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = " \u25fc ";
                }
            }
        }

        public void PrintUniverse()
        {
            var width = Cells.GetLength(0);
            var height = Cells.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(Cells[i, j]);
                }
                Console.Write('\n');
            }
        }
    }
}