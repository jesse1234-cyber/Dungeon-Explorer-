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
            Console.WriteLine("Please enter your name: ");
            var playerName = Console.ReadLine();
            // validate player name

            player = new Player(playerName, 100);
            Start();
        }
        public void Start()
        {
            Console.WriteLine(Player.Name);

            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}