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
            currentRoom = new Room();
            player = new Player("Username", 10);

        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Please enter a username: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)){
                    name = "Blank";
                }
                Console.WriteLine($"Hello {name}!");

                ConsoleKey Key;
                do
                {
                    Console.WriteLine("Press Enter to start the game...");
                    Key = Console.ReadKey(true).Key;
                }
                while (Key != ConsoleKey.Enter);

                Console.WriteLine(currentRoom.GetDescription());

                Console.WriteLine("\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;

            }
        }
    }
}