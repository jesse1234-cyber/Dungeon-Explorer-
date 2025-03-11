using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Room nextRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("room 1: entrance", "a torch", 2, 2, 1);
            nextRoom = new Room("room 2: passage", "a key", 5, 2, 4);
            List<string> playerInventory = new List<string>();
            player = new Player("player", 100, playerInventory);
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                player.setPlayerName();
                currentRoom.WriteDescription();
                player.PickUpItem(currentRoom.RoomItem);
                playing = false;
            }
        }
    }
}