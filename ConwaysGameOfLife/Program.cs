using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SpecialCharacters specialCharacters = new SpecialCharacters();
            specialCharacters.CreateGrid();*/
            Universe uni = new Universe(10);
            uni.CreateUniverse();
            uni.PrintUniverse();

        }
    }
}