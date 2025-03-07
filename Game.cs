using System;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        { 
            player = new Player("PlayerName", 100); 
            currentRoom = new Room("Starting Room"); 
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("You have been captured and thrown into a dungeon. Instruct yourself on ways to escape, fellow hero!");
        }

        public object Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine("Choose an action");
                Console.WriteLine("");
                Console.WriteLine("1. Check room description");
                Console.WriteLine("2. Pick up an item");
                Console.WriteLine("3. Check inventory");
                Console.WriteLine("4. Check health");
                Console.WriteLine("5. Attempt to leave the dungeon");
                Console.WriteLine("6. Exit game");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "2":
                        Console.WriteLine("Looking around the room, you see that you are in a room with limited spare goods which can help you on your journey. There is one sword, a singular key, and a rugged used cap on a stand. Which item do you pick up? (sword/cap/key): ");
                        string item = Console.ReadLine();
                        if (item == "sword" || item == "cap" || item == "key")
                        {
                            player.PickUpItem(item);
                            Console.WriteLine($"{item} has been added to your inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid item. You can only pick up 'sword', 'cap', or 'key'.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Inventory: ");
                        Console.WriteLine(player.InventoryContents());
                        break;
                    case "4":
                        Console.WriteLine("Health: ");
                        Console.WriteLine(player.Health);
                        break;
                    case "5":
                        if (EndGame())
                        {
                            playing = false;
                            Console.WriteLine("You use the key to escape the dungeon.");
                        }
                        else
                        {
                            Console.WriteLine("You need a key to escape the dungeon.");
                        }
                        break;
                    case "6":
                        playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            return null;
        }

        public bool EndGame()
        {
            if (player.InventoryContents().Contains("key"))
            {
                Console.WriteLine("You have successfully escaped the dungeon!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}