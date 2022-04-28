using System;

namespace ConwaysGameOfLife
{
    public class Universe
    {
        private IConsole seedConsole;
        public int seedDimensions;
        public string Content { get; set; }
        public string [,] Cells { get; set; } //Cell array == Universe grid

        public Universe(IConsole seedSettings) //ask for grid size (seed dimensions), then ask for dead or alive cells to be set
        {
            seedConsole = seedSettings;
            Cells = new String[seedDimensions, seedDimensions];
        }
        
        /*public void CreateUniverse()
        {
            var width = Cells.GetUpperBound(0) + 1;
            var height = Cells.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = " \u25fc "; //cube shape
                }
            }
        }*/
        
        public void CreateUniverse()
        {
            var width = Cells.GetUpperBound(0) + 1;
            var height = Cells.GetUpperBound(1) + 1;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = " . "; 
                }
            }
        }

        public void DisplayUniverse()
        {
            var width = Cells.GetLength(0);
            var height = Cells.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //Console.ForegroundColor = new Cell().Colour ; //
                    //Cells[i, j] = new Cell().Symbol; 
                    Console.Write(Cells[i, j]); //cell status - modify the Foregroundcolour
                }
                Console.Write('\n');
            }
        }

        private void UpdateUniverse()
        {
            
        }
    }
}