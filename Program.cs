//This file is for the main program loop- most likely the "main" menu of starting/stopping the game (links to the "Game.cs" file)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args) // Belongs to the class, and is not an object (method would start each time program is ran?)
        {
            Game game = new Game(); // game is an object of the class Game
            game.Start();

            // May remove these lines/modify to put in "Start()" for the Game.cs
            Console.WriteLine("Waiting for your Implementation");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
