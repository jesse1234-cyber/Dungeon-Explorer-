using System;
using System.Media;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("a dark and cold dungeon room");
            Console.WriteLine("Please enter a username: ");
            player = new Player(Console.ReadLine(), 100);
            Console.WriteLine($"Welcome {player.Name}");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine("Entering Dungeon...");
                currentRoom.GetDescription();
                Console.WriteLine("Press A to move right, D to move left or W to move forward");
                string userMoveInput = Console.ReadLine();
                if (userMoveInput == "A")
                {
                    Console.WriteLine("Moving to the right");
                    Console.WriteLine("You have found a golden sword");
                    player.PickUpItem("A golden sword");
                    player.InventoryContents();
                }

                else if (userMoveInput == "D")
                {
                    Console.WriteLine("Moving to the left");
                    Console.WriteLine("You have found a bow and arrow");
                    player.PickUpItem("A bow and arrow");
                    player.InventoryContents();
                }

                else if(userMoveInput == "W")
                {
                    Console.WriteLine("Moving forwards");
                    Console.WriteLine("You have found armour");
                    player.PickUpItem("Armour");
                    player.InventoryContents();
                }

                else
                {
                    Console.WriteLine("You must enter an appropriate input (A, D or W)");
                }

                break;
                
            }
        }
    }
}