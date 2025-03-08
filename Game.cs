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
            Console.WriteLine("Welcome to the Dungeon Explorer Game!");
            Console.Write("Enter your preferred character name: ");
            string name = Console.ReadLine();
            player = new Player(name, 100);
            currentRoom = new Room("small dark room with a flickering flame in the middle that ever so slightly lightens up the room, and the sound of water pattering against the floor echos throughout.");
            // Initialize the game with one room and one player
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine($"Welcome, Tarnished {player.Name}. You are about to embark on your new journey in these dungeons but be careful on your discovery as who knows what you may find, remember you only have {player.Health} health.");
            Console.WriteLine($"You are currently in a {currentRoom.GetDescription()}.");
            while (playing)
            {
                Console.WriteLine("To begin your journey you will have to decide what you want to do from the following...");
                Console.WriteLine("1) Room description");
                Console.WriteLine("2) Explore room ");
                Console.WriteLine("3) Check inventory");
                Console.WriteLine("4) Check health");
                Console.WriteLine("5) Exit the game");
                Console.Write("Your choice: ");
                
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine($"You are in a {currentRoom.GetDescription()}.");
                        break;
                    case "2":
                        Console.Write("During your search around the room");
                        player.PickUpItem();
                        break;
                    case "3":
                        Console.Write("You chose to check your inventory, ");
                        player.InventoryContents();
                        break;
                    case "4":
                        Console.WriteLine($"You are currently at {player.Health} health.");
                        break;
                    case "5":
                        Console.WriteLine("You are about to exit the game. Thanks for playing.");
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please choose a valid option");
                        continue;
                }
            }
        }
    }
}