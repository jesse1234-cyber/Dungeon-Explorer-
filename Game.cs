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
            player = Player()
            currentRoom = Room()
            Console.WriteLine("You awaken. Your head is pounding, and the suffocating air, thick with dust, clings to your lungs. Where are you? How did you get here?")
            currentRoom.GetDescription()

            // Initialize the game with one room and one player

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                Console.WriteLine("You look around the cold library, squinting while your eyes adjust. Something glistens in the corner of the room, and you hear groans from the other side." +
                    "What do you do?" +
                    "A: Investigate the peculiar glistening\nB: Investigate the creepy groaning\nC: Rummage through the piles of books and skim through the bookshelves");
                // Code your playing logic here
                playerChoice = Console.ReadLine();
                
            }
        }
    }
}