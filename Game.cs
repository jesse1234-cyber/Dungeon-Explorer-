using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            int room = 1;
            int Player = 1;
            // Initialize the game with one room and one player

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing == true)
            {
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine(player.Health());
                Console.WriteLine(player.Inventory());

                // Code your playing logic here
            }
        }
    }
}f