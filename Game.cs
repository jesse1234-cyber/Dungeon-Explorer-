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
            player = new Player("Player1", 100); // Assuming Player has a constructor for Name and Health

            // Initialize the first room with a description
            currentRoom = new Room("A dark room with stone walls. There seems to be something glimmering in the corner.");
        }

        public void Start()
        {
            // Start the game loop
            bool playing = true; 

            while (playing)
            {
                // Display the room's description
                Console.WriteLine(currentRoom.GetDescription());
                
                // Display the player's current status
                DisplayPlayerStatus();

                // Ask the player what they want to do
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Status");
                Console.WriteLine("2. Pick up Item");
                Console.WriteLine("3. Exit Game");
                
                string input = Console.ReadLine();

                // Handle user input
                switch (input)
                {
                    case "1":
                        DisplayPlayerStatus();
                        break;

                    case "2":
                        Console.WriteLine("Enter the name of the item you want to pick up:");
                        string item = Console.ReadLine();
                        player.PickUpItem(item);
                        Console.WriteLine($"{item} has been added to your inventory.");
                        break;

                    case "3":
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
            Console.WriteLine($"\nPlayer: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Inventory: {player.InventoryContents()}");
        }
    }
}
