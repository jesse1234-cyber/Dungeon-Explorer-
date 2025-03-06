using System;
using System.IO;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player = new Player(); // Creates a new player entity.
        private Room room1 = new Room(); // Creates a new room entity.

        // Constructor which initializes the game with a player name and room description.
        public Game()
        {
            Console.Write("Enter the player name: ");
            string new_name = Console.ReadLine(); // Get player name from input.
            player.Name = new_name; // Set player name.
            player.Health = 100; // Set player health.
            room1.Description = File.ReadAllText(@"Descriptions/room1.txt"); // Read room description from a text file and set it.
            room1.AddItem("Key"); // Add key item to room.

        }

        // Method to start the game and handle user commands.
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // Display options to player.
                Console.WriteLine("Type help for a list of commands");
                Console.Write("Enter command: ");
                string user_input = Console.ReadLine().ToLower();
                // Help command displays other available commands to player.
                if (user_input == "help")
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("Status - displays the players' name, health and inventory.");
                    Console.WriteLine("Description - displays the description of the room.");
                    Console.WriteLine("Pick up [item name] - picks up an item from the room.");
                    Console.WriteLine("Quit - exits the game.");
                }
                else if (user_input == "status") // Display player status.
                {
                    Console.WriteLine("Name: " + player.Name);
                    Console.WriteLine("Health: " + player.Health);
                    Console.WriteLine("Inventory: " + player.InventoryContents());
                }
                else if (user_input == "description") // Display room description.
                {
                    room1.GetDescription();
                }
                else if (user_input.StartsWith("pick up")) // Pick up items.
                {
                    string pick = user_input.Substring(8).Trim();
                    if (!string.IsNullOrEmpty(pick))
                    {
                        player.PickUpItem(pick, room1); // Calls the method to pick up the item.
                    }
                    else
                    {
                        Console.WriteLine("No item provided. Please specify which item you want to pick up.");
                    }
                }
                else if (user_input == "quit") // Quis the game.
                {
                    Console.WriteLine("Exiting....");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid command!"); // Displayed if an invalid command is displayed.
                }
            }
        }
    }
}