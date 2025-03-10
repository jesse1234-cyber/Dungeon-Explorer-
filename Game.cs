using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private List<Room> rooms;
        private Room currentRoom;

        public Game()
        {
            // Initialize the player
            player = new Player("Player1", 100);

            // Initialize rooms
            rooms = new List<Room>
            {
                new Room("The First Room", "A dark and quiet room.", new List<string> { "Sword" }),
                new Room("The Second Room", "A bright room with a table.", new List<string> { "Shield" })
            };

            // Set the starting room
            currentRoom = rooms[0];
        }

        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine($"Inventory: {player.InventoryContents()}");
                DisplayPlayerStatus();

                // Ask the player what they want to do
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Move to next room");
                Console.WriteLine("3. Exit Game");
                string input = Console.ReadLine();

                // Handle user input
                switch (input)
                {
                    case "1":
                        if (currentRoom.HasItems())
                        {
                            Console.WriteLine($"Items in the room: {string.Join(", ", currentRoom.GetItems())}");
                            Console.Write("Enter item to pick up: ");
                            string itemToPick = Console.ReadLine();
                            if (currentRoom.PickUpItem(itemToPick, player))
                            {
                                Console.WriteLine($"{itemToPick} picked up!");
                            }
                            else
                            {
                                Console.WriteLine("Item not found in the room.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no items in this room.");
                        }
                        break;

                    case "2":
                        // Move to the next room
                        int currentIndex = rooms.IndexOf(currentRoom);
                        currentRoom = rooms[(currentIndex + 1) % rooms.Count];
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

                // Pause before next turn
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public void DisplayPlayerStatus()
        {
            Console.WriteLine($"Player: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
        }
    }
}
