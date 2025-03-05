using System;
using System.Media;
using System.Net.Mime;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Anonymous", 100);
            currentRoom = new Room("You're in a dark room with some dim light coming from torch.");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            
            // Display the starting information to the player
            Console.WriteLine($"\nWelcome to the beginning of your adventure, {player.Name}!\n\n" +
                              $"You have {player.GetHealth()} HP.\n" +
                              $"You inventory: {player.InventoryContents()}\n" +
                              $"{currentRoom.GetDescription()}\n");
            
            bool playing = true;
            while (playing) 
            {
                // Display available options.
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("View room description: a");
                Console.WriteLine("View stats (health and inventory): b");
                Console.WriteLine("Pick up an item: c");
                Console.WriteLine("Exit game: d");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine("\nRoom Description: " + currentRoom.GetDescription());
                        break;
                    case "b":
                        Console.WriteLine("\nCurrent stats:");
                        Console.WriteLine($"Health: {player.GetHealth()} HP");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;
                    case "c":
                        player.PickUpItem("Example"); // Yet to be randomised and implemented.
                        break;
                    case "d":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid choice.");
                        break;
                }
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}