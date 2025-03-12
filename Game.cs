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
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            player = new Player(name);
            currentRoom = new Room(" ");
            int room = 1;
            player = new Player({player });
            // Initialize the game with one room and one player

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            
            if (health >=1)
            {
                bool playing = true;
            }
            else if (health <= 0)
            {
                bool playing = false;
            }
            while (playing)
            {
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine(player.Health());
                Console.WriteLine(player.Inventory());

                // Code your playing logic here
            }
        }
    }
}