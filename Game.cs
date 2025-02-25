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
                    player.PickUpItem("A golden sword");
                }

                else if (userMoveInput == "D")
                {

                }

                else if(userMoveInput == "W")
                {

                }

                else
                {
                    Console.WriteLine("You must enter an appropriate input (A, D or W)");
                }
                
            }
        }
    }
}