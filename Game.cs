using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("Room 1", "Sword");
            List<string> playerInventory = new List<string>();
            player = new Player("Default Name", 100, playerInventory);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                player.ChooseName();
                currentRoom.GetDescription(player);
                playing = false;
            }
        }
    }
}