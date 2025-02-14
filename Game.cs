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

        }
        public void Start()
        {
            bool nameSelect = true;
            bool playing = false;
            string name = "";

            // Code for selecting name for the character
            while (nameSelect)
            {
                Console.Write("What is your character's name: ");
                name = Console.ReadLine();
                Console.WriteLine($"Is {name} the right name? y/n");
                string desision = Console.ReadLine().ToLower();
                if (desision == "y") nameSelect = false;
            }

            // Initalise Player Class
            player = new Player(name, 10);

            // Main Game loop
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}