using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player1;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player

            player1 = new Player("", 0, new List<string>());
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here

                //Instantiating player object
                Console.WriteLine("Enter the player's name: ");
                player1.Name = Console.ReadLine();

                player1.Health = 100;

                player1.Inventory = new List<string>();

                Console.WriteLine($"Player's name is: {player1.Name} \n{player1.Name}'s health is: {player1.Health} \nInventory is empty\nPress any key to begin your adventure...");
                Console.ReadKey();
            }
        }
    }
}