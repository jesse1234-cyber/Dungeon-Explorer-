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
                Game.Story(); //story filler after first fight
                while (currentPlayer.roomCount <= 5 && currentPlayer.health > 0) //wile loop for wile the player has not compled each room and the player is alive
                {
                    Rooms.roomActions(); //generate a new room
                    currentPlayer.roomCount += 1; //add a room to the room count
                }
                if (currentPlayer.roomCount == 6 && currentPlayer.health > 0) //is statment to say the player has won if they are alive and have cmpleted all rooms
                    victory = true;
            }

            //TEMPORARY
            if (victory == true)
               Game.Winner(); //win message

            else
                Game.Death(); //lose meaage
        }
    }
}
