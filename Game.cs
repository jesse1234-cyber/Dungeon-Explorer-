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
            player = new Player("Player");
            currentRoom = new Room("You are in a dungeon.There is a sword on the ground near by.");
            currentRoom.AddItem("sword"); // creates a sword.

        }
        public void Start()
        {
            Console.WriteLine("Dungeon Explorer"); //displays the title of the game.
            bool playing = true; // this will check to see if the game is still running
            while (playing)
            {
              // Shows the current room info
              Console.WriteLine(currentRoom.GetDescription());
              Console.WriteLine("Items in room: " + currentRoom.ListItems());

              // make the player choose an option
              Console.WriteLine("Pick one of these options below");
              Console.WriteLine("Options: 1.'pick up [item]', 'inventory', 'move [direction]', 'exit'");

                // player input
                string input = Console.ReadLine().ToLower();

                // this will process the player input
                if (input.StartsWith("pickup"))
                {
                    string item = input.Substring(8).Trim();
                    if (currentRoom.ListItems().Contains(item))
                    {
                        currentRoom.RemoveItem(item); ; // removes item from room.
                        player.PickUpItem(item); // adds item to players inventory.
                    }
                    else
                    {
                        Console.WriteLine("[item] is not in this room.");
                    }
                }
                else if (input == "inventory")
                {
                    // display the player inv
                    Console.WriteLine("Your inventory: " + player.InventoryContents());
                }
                else if (input == "exit")
                {
                    // exit game
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                }
                else
                {
                    //handle invalid inputs
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}