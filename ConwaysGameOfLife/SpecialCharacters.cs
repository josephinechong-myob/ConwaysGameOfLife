using System;
using System.Text;

namespace ConwaysGameOfLife
{
    public class SpecialCharacters
    {
        private const int SizeX = 5;
        private const int SizeY = 5;
        
        public void DisplayingSpecialCharacter()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            
            Console.WriteLine("\u2103");
            Console.WriteLine("\u00a9");
            Console.WriteLine("\u00b2");
            Console.WriteLine("\u00bd");
            
        }

        public void CreateGrid()
        {
            for (int y = SizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write(" \u25fc "); 
                }
                Console.Write('\n');
            }
            
            
        }
    }
}