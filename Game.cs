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
            // Initialize the game with one room and one player
            //Player player = new Player(, 100);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            Player player = new Player("Mitchell", 100);
            Console.WriteLine($"Player Name: {player.Name} \nPlayer Health: {player.Health}");
            
            //Console.WriteLine($"The player: {}");
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}