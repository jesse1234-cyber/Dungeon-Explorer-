using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one player and one room
            player = new Player("Player1", 100);
            currentRoom = new Room("The First Room", "A dark and quiet room.", "Ancient Sword"); // Example room with an item
        }

        public void Start()
        {
            bool playing = true;  // Start the game

            while (playing)
            {
                // Display the room description
                Console.WriteLine(currentRoom.GetDescription());

                // Display player status and inventory
                DisplayPlayerStatus();

                // Ask the player what they want to do
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Status");
                Console.WriteLine("2. Pick up item");
                Console.WriteLine("3. Exit Game");
                string input = Console.ReadLine();

                // Handle user input
                switch (input)
                {
                    case "1":
                        // View player status
                        DisplayPlayerStatus();
                        break;

                    case "2":
                        // Pick up the item in the room
                        if (currentRoom.HasItem())
                        {
                            string pickedItem = currentRoom.PickUpItem();  // Pickup the item
                            player.PickUpItem(pickedItem);  // Add it to the player's inventory
                            Console.WriteLine(pickedItem);  // Show feedback to the player
                        }
                        else
                        {
                            Console.WriteLine("No items to pick up in this room.");
                        }
                        break;

                    case "3":
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
            // Display the player's current name, health, and inventory contents
            Console.WriteLine($"Player: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Inventory: {player.InventoryContents()}");
        }
    }
}
