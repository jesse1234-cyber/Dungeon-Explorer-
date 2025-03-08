using System;
using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public string Username { get; private set; }
        private GameTests testing = new GameTests();

        public Game()
        {
            currentRoom = new Room();
            player = new Player("Username", 10);
        }


        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Username = player.GetName();
                Console.WriteLine($"Hello, {Username}!");
                ConsoleKey Key;
                do
                {
                    Console.WriteLine("Press Enter to start the game...");
                    Key = Console.ReadKey(true).Key;
                }
                while (Key != ConsoleKey.Enter);

                int TurnCount = 6;
                while (TurnCount > 0)
                {
                    Console.WriteLine(currentRoom.GetDescription());
                    string item = currentRoom.GetItems();

                    Console.WriteLine($"\nIn the room there is a {item}." +
                        " Press Space to pick it up, I to check your inventory, or Enter to carry on...");
                    ConsoleKey PickupInput;
                    PickupInput = Console.ReadKey(true).Key;

                    bool condition = true;
                    while (condition == true)
                    {
                        if (PickupInput == ConsoleKey.Spacebar)
                        {
                            player.PickUpItem(item);
                            condition = false;
                        }
                        else if (PickupInput == ConsoleKey.I)
                        {
                            Console.WriteLine($"Your inventory currently has: {player.InventoryContents()}");
                            Console.WriteLine($"Press Space to pick up {item}, or Enter to continue");
                            PickupInput = Console.ReadKey(true).Key;
                        }
                        else if (PickupInput == ConsoleKey.Enter)
                        {
                            condition = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter Space to pick up or Enter to continue");
                        }
                    }
                    TurnCount -= 1;

                }


                Console.WriteLine("\nYou made it throught the dungeon! Thanks for playing." +
                    $"\nIn the end you collected: {player.InventoryContents()}" +
                    "\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;

            }
        }
    }
}