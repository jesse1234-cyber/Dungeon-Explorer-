﻿//This file is for the main program loop- most likely the "main" menu of starting/stopping the game (links to the "Game.cs" file)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// MUST add "debug.assert" as part of the CRG (to the other files?)
// Need to include: explanation on encapuslation (within video; making things private to a specific class- get and set methods)
// Item ideas; torch, exit key, knife (max four items? key should always be availble in one room)

namespace DungeonExplorer
{
    internal class Program // Calls all relevant 
    {
        static void Main(string[] args) // Belongs to the class, and is not an object (static)
        {
            NewPlayer.InputName(); // Program starts with name input
            Game game = new Game(); // game is an object of the class Game
            game.Start();
        }
    }
}
