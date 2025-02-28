using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player1;
        private Room room1;

        public Game()
        {
            // Initialize the game with one room and one player
            player1 = new Player("Test Player");
            room1 = new Room("Start", "This is the first room. It is empty. There is a locked door to the north.");

        }
        public void Start()
        {

            bool playing = true;
            while (playing)
            {
                
                Console.WriteLine(player1.GetPlayerData());
                Console.WriteLine(room1.GetDescription());
                playing = false;

            }
        }
    }
}