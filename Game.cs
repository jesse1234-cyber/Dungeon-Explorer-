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
            // Initialize the player
            player = new Player("Hero", 100);

            // Create a simple room with an item
            currentRoom = new Room("A dark and eerie dungeon room. A single torch flickers on the wall.", "Rusty Key");
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine($"You find yourself in: {currentRoom.GetDescription()}");

            bool playing = true;

            while (playing)
            {
                Console.WriteLine("\nWhat do you want to do? (look/move/take/inventory/quit)");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "look":
                        Console.WriteLine($"You look around: {currentRoom.GetDescription()}");
                        if (currentRoom.Item != null)
                        {
                            Console.WriteLine($"You see a {currentRoom.Item} on the ground.");
                        }
                        break;

                    case "move":
                        Console.WriteLine("You move deeper into the dungeon...");
                        // Future expansion: Add multiple rooms
                        break;

                    case "take":
                        if (currentRoom.Item != null)
                        {
                            player.PickUpItem(currentRoom.Item);
                            Console.WriteLine($"You picked up {currentRoom.Item}.");
                            currentRoom.RemoveItem();
                        }
                        else
                        {
                            Console.WriteLine("There's nothing to take.");
                        }
                        break;

                    case "inventory":
                        Console.WriteLine("Your inventory: " + player.InventoryContents());
                        break;

                    case "quit":
                        playing = false;
                        Console.WriteLine("Thanks for playing!");
                        break;

                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }
    }

    public class Room
    {
        public string Description { get; }
        public string Item { get; private set; }

        public Room(string description, string item = null)
        {
            Description = description;
            Item = item;
        }

        public void RemoveItem()
        {
            Item = null;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
