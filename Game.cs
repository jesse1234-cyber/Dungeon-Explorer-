using System;
using System.ComponentModel;
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
                string item = currentRoom.GetItems();
                Console.WriteLine($"In the room there is a {item}." +
                    "Press Space to pick it up, or Enter to carry on...");
                ConsoleKey PickupInput;
                PickupInput = Console.ReadKey(true).Key;
                while (true)
                {
                    if (PickupInput == ConsoleKey.Spacebar)
                    {
                        player.PickUpItem(item);
                        return;
                    }
                    else if (PickupInput == ConsoleKey.Enter)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter Space to pick up or Enter to continue");
                    }
                }





                Console.WriteLine("\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;

            }
        }
    }
}