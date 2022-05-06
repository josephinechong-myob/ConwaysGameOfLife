using System;
using System.Collections.Generic;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
        
    // 3) option need to be available when user is happy with their seed settings and wants to exit and start the program
    {
        //public static Option[,] options;

        static void Main(string[] args)
        {
            /*SpecialCharacters specialCharacters = new SpecialCharacters();
            specialCharacters.CreateGrid();*/
            var console = new SeedConsole();
            var seed = new Seed(console);
            var dimensions = seed.SeedDimensions;
            var setSeed = seed.SeedInitialState;
        }

        //         options = new [,]
    //         {
    //             {
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Hi")), //Update Cell State (dead or alive) - show that cell has been updated (colour)
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("How are you")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Today")),
    //                 new Option(" \n ", () => Environment.Exit(0))
    //             },
    //             {
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Hi")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("How are you")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Today")),
    //                 new Option(" \n ", () => Environment.Exit(0))
    //             },
    //             {
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Hi")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("How are you")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Today")),
    //                 new Option(" \n ", () => Environment.Exit(0))
    //             },
    //             {
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Hi")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("How are you")),
    //                 new Option(" \u25fc ", () => UpdateSelectedCellStateForSeed("Today")),
    //                 new Option(" \n ", () => Environment.Exit(0))
    //             }
    //         };
    //
    //         int column = 0;
    //         int row = 0;
    //
    //         WriteMenu(options, options[column, row]);
    //         ConsoleKeyInfo keyinfo;
    //         do
    //         {
    //             keyinfo = Console.ReadKey();
    //
    //             if (keyinfo.Key == ConsoleKey.DownArrow)
    //             {
    //                 if (column + 1 < options.Length)
    //                 {
    //                     column++;
    //                     WriteMenu(options, options[column, row]);
    //                 }
    //             }
    //
    //             if (keyinfo.Key == ConsoleKey.UpArrow)
    //             {
    //                 if (column - 1 >= 0)
    //                 {
    //                     column--;
    //                     WriteMenu(options, options[column, row]);
    //                 }
    //             }
    //
    //             if (keyinfo.Key == ConsoleKey.RightArrow)
    //             {
    //                 if (row + 1 < options.Length)
    //                 {
    //                     row++;
    //                     WriteMenu(options, options[column, row]);
    //                 }
    //             }
    //
    //             if (keyinfo.Key == ConsoleKey.LeftArrow)
    //             {
    //                 if (row - 1 >= 0)
    //                 {
    //                     row--;
    //                     WriteMenu(options, options[column, row]);
    //                 }
    //             }
    //
    //             if (keyinfo.Key == ConsoleKey.Enter)
    //             {
    //                 options[column, row].Selected.Invoke();
    //                 column = 0;
    //             }
    //         } while (keyinfo.Key != ConsoleKey.X);
    //
    //         Console.ReadKey();
    //     }
    //
    //
    // static void UpdateSelectedCellStateForSeed(string message)
    //     {
    //         Console.Clear();
    //         Console.Write(message);
    //         //update cell state 
    //         //update cell colour
    //        // Console.ForegroundColor = ConsoleColor.Magenta;
    //         Thread.Sleep(3000);
    //         WriteMenu(options, options[0, 0]);
    //     }
    //
    //     static void WriteMenu(Option[,] options, Option selectedOption)
    //     {
    //         Console.Clear();
    //         foreach (Option option in options)
    //         {
    //             if (option == selectedOption)
    //             {
    //                 //Console.Write("> ");
    //                 Console.ForegroundColor = ConsoleColor.Red;
    //             }
    //             else
    //             {
    //                 //Console.Write(" ");
    //                 Console.ForegroundColor = ConsoleColor.Cyan;
    //             }
    //
    //             Console.Write(option.Name);
    //         }
    //     }
    //
    //     public class Option
    //     {
    //         public string Name { get; }
    //         public Action Selected { get; }
    //
    //         public Option(string name, Action selected)
    //         {
    //             Name = name;
    //             Selected = selected;
    //         }
    //     }
    }
}