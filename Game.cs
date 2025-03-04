using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public string Game()
        {
            Console.WriteLine("Please input your name:");
            string userName = Console.ReadLine();
            Player user = new Player(userName, 15);


        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Please input your name:");
                string userName = Console.ReadLine();
                Game();
                Console.WriteLine("Hello " + user.Name)
            }
        }
    }
}