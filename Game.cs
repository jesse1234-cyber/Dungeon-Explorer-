using System;
using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        // Private sets.
        public Player player { get; private set; }
        public Room currentRoom { get; private set; }
        public Test testing = new Test();
        public string Username { get; private set; }

        public Game()
        {
            currentRoom = new Room();
            player = new Player("Username", 10);
        }

        /// Method to start the main game loop.
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                testing.RunTests();
                // Gets the users name.(Calls GetName())
                Username = player.GetName();
                Console.WriteLine($"Hello, {Username}!");
                ConsoleKey Key;
                do
                {
                    Console.WriteLine("Press Enter to start the game...");
                    Key = Console.ReadKey(true).Key;
                }
                while (Key != ConsoleKey.Enter);

                // The player has 6 turns to go through the dungeon.
                int TurnCount = 6;
                while (TurnCount > 0)
                {
                    // Gets the description and item for the room.(Calls GetDescription() and GetItems())
                    Console.WriteLine(currentRoom.GetDescription());
                    string item = currentRoom.GetItems();
                    // Gets the users input to continue.
                    Console.WriteLine($"\nIn the room there is a {item}." +
                        " Press Space to pick it up, I to check your inventory, or Enter to carry on...");
                    ConsoleKey PickupInput;
                    PickupInput = Console.ReadKey(true).Key;

                    // Loops until the user enters a valid input.
                    bool condition = true;
                    while (condition == true)
                    {
                        if (PickupInput == ConsoleKey.Spacebar)
                        {
                            // Adds the item to the inventory list. (Calls PickUpItem())
                            player.PickUpItem(item);
                            condition = false;
                        }
                        else if (PickupInput == ConsoleKey.I)
                        {
                            // Displays the contents of the inventory. (calls InventoryContents())
                            Console.WriteLine($"Your inventory currently has: {player.InventoryContents()}");
                            Console.WriteLine($"Press Space to pick up {item}, or Enter to continue");
                            PickupInput = Console.ReadKey(true).Key;
                        }
                        else if (PickupInput == ConsoleKey.Enter)
                        {
                            // Continues the game.
                            condition = false;
                        }
                        else
                        {
                            // Ensures the input was valid.
                            Console.WriteLine("Please enter Space to pick up or Enter to continue");
                        }
                    }
                    TurnCount -= 1;

                }

                // Displays the inventory before ending the game.
                Console.WriteLine("\nYou made it through the dungeon! Thanks for playing." +
                    $"\nIn the end you collected: {player.InventoryContents()}" +
                    "\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;

            }
        }
    }
}