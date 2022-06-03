﻿using ConwaysGameOfLife.Controller;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var console = new GameConsole();
            var game = new Game(console);
            
            game.Options();
        }
    }
}