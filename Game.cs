using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Ask the player for their name
            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine();

            // If the player doesn't enter anything, default to "Adventurer"
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Adventurer";
            }

            // Initialize player and room
            player = new Player(playerName);
            currentRoom = new Room("A dark, eerie dungeon chamber. There’s an old key on the ground.", "Old Key");
        }

        public void Start()
        {
            bool playing = true; // Game loop control variable
            while (playing)
            {
                // Display available actions to the player
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. View Room Description");
                Console.WriteLine("2. Pick Up Item");
                Console.WriteLine("3. Check Player Status");
                Console.WriteLine("4. Exit Game");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine(); // Get player input

                
                switch (choice)
                {
                    case "1":
                        
                        Console.WriteLine($"Room: {currentRoom.GetDescription()}");
                        break;
                    case "2":
                        // Attempt to pick up an item
                        string item = currentRoom.TakeItem();
                        if (item != "No items left to take.")
                        {
                            player.PickUpItem(item);
                        }
                        else
                        {
                            Console.WriteLine("There's nothing left to pick up.");
                        }
                        break;
                    case "3":
                       
                        player.DisplayStatus();
                        break;
                    case "4":
                     
                        Console.WriteLine("Exiting game...");
                        playing = false;
                        break;
                    default:
                        // Handle invalid inputs
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}