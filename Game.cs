using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;   // The player in the game
        private Room currentRoom; // The current room the player is in

        // Constructor to initialize the game
        public Game()
        {
            // Ask the player for their name
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();  // Get player name input

            // Initialize the player with the entered name and a default health of 100
            player = new Player(playerName, 100);

            // Initialize the room with a description and an item ("sword")
            currentRoom = new Room("You are in a dark, damp dungeon room.", "sword");
        }

        // Method to start the game
        public void Start()
        {
            bool playing = true;

            // Game loop
            while (playing)
            {
                // Display current room description and player status
                Console.Clear();
                Console.WriteLine($"Welcome {player.Name}!");
                Console.WriteLine("Room: " + currentRoom.GetDescription());
                Console.WriteLine("Health: " + player.Health);
                Console.WriteLine("Inventory: " + player.InventoryContents());

                // Check if there's an item in the room and display it
                if (!string.IsNullOrEmpty(currentRoom.GetItem()))
                {
                    Console.WriteLine($"There is a {currentRoom.GetItem()} in the room.");
                }

                // Player options
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Exit game");
                Console.WriteLine("3. View status"); // Added option to view status
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Allow the player to pick up the item if it's in the room
                        string item = currentRoom.GetItem();
                        if (item != null)
                        {
                            player.PickUpItem(item);  // Add item to inventory
                            currentRoom.RemoveItem();  // Remove the item from the room
                            Console.WriteLine($"You picked up a {item}.");
                        }
                        else
                        {
                            Console.WriteLine("There is no item to pick up.");
                        }
                        break;

                    case "2":
                        // Exit the game
                        Console.WriteLine("Exiting the game...");
                        playing = false;
                        break;

                    case "3":
                        // View the player's current status
                        Console.WriteLine("\n*** Player Status ***");
                        Console.WriteLine("Health: " + player.Health);
                        Console.WriteLine("Inventory: " + player.InventoryContents());
                        Console.WriteLine("Press any key to return to the game...");
                        Console.ReadKey();  // Wait for user to press a key to return to game
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Example of game-ending condition: player health reaches 0
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died. Game over!");
                    playing = false;
                }
            }
        }
    }
}
