﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * This function starts the program
             * Inputs:
             * None
             * Outputs:
             * None
             */
            Game game = new Game();
            game.Start();
            Console.WriteLine("Waiting for more Implementation");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
