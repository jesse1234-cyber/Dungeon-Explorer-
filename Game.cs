using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Player1", 100);  // Create a player with name and health
            currentRoom = new Room("First Room", "A dark room with a flickering torch.", "Sword");  // Create a room with a description and an item
        }

        public void Start()
        {
            bool playing = true;  // Set to "true" to start game

            while (playing)
            {
                // Show room description and player status
                Console.Clear();  // Clears the console for better readability
                Console.WriteLine(currentRoom.GetDescription());  // Display the current room's description
                DisplayPlayerStatus();  // Display player status (health, inventory)

                // Ask the player what they want to do
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Status");
                Console.WriteLine("2. Pick up an item (if available)");
                Console.WriteLine("3. Exit Game");
                string input = Console.ReadLine();

                // Handle user input with error handling
                switch (input)
                {
                    case "1":
                        // View player status
                        DisplayPlayerStatus();
                        break;

                    case "2":
                        // If room has an item, let the player pick it up
                        if (currentRoom.HasItem())
                        {
                            string item = currentRoom.PickUpItem();  // Pick up item from the room
                            player.PickUpItem(item);  // Add item to the player's inventory
                            Console.WriteLine($"You picked up a {item}.");
                        }
                        else
                        {
                            Console.WriteLine("No items available in this room.");
                        }
                        break;

                    case "3":
                        // Exit the game
                        Console.WriteLine("Exiting game...");
                        playing = false;
                        break;

                    default:
                        // Handle invalid commands gracefully
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Wait for user to press a key before continuing to the next step
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public void DisplayPlayerStatus()
        {
            // Show the player's current status: name, health, and inventory
            Console.WriteLine($"Player: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Inventory: {player.InventoryContents()}");
        }
    }
}
