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
            player = new Player("Player1", 100); // Assuming Player has a constructor for Name and Health

            // Initialize the first room
            currentRoom = new Room("The First Room", "A dark room.");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true; // Set to "true" to start game

            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine(currentRoom.GetDescription());
                // Display the player's current status
                DisplayPlayerStatus();
        
                // Ask the player what they want to do (simple actions like 'view status' or 'exit')
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View Status");
                Console.WriteLine("2. Exit Game");
                string input = Console.ReadLine();

                // Handle user input
                switch (input)
                {
                    case "1":
                        // View player status (health, inventory)
                        DisplayPlayerStatus();
                        break;
                    case "2":
                        // Exit the game
                        Console.WriteLine("Exiting game...");
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }


        public void DisplayPlayerStatus()
        {
            Console.WriteLine($"Player: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Inventory: {player.Inventory}");
    }