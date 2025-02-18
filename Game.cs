using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Game class
    /// Sets up the main gameplay
    /// </summary>
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;

        /// <summary>
        /// Creates new objects for the Room and Player class
        /// </summary>
        public Game()
        {
            // Initialize the game with one room and one player
            _currentRoom = new Room("Room 1", "Sword");
            List<string> playerInventory = new List<string>();
            _player = new Player("Default Name", 100, playerInventory);
        }

        /// <summary>
        /// Begins the game logic
        /// </summary>
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                _player.ChooseName();
                _currentRoom.GetDescription(_player);
                playing = false;
            }
        }
    }
}