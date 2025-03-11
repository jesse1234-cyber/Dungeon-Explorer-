using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        public static Player currentPlayer = new Player(); // creat new player instence
        static void Main(string[] args)
        {
            bool victory = false; //the player has not yet won
            while (currentPlayer.health > 0 && victory == false) //while the player is alive and they have no won, loop the game
            {
                Game.Start(); // game intro
                Encounters.FirstEncounter(); //first fight
                Game.Story(); //story filler after first fight
            }
        }
    }
}
