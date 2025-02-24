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

                int TurnCount = 6;
                while (TurnCount > 0)
                {
                    Console.WriteLine(currentRoom.GetDescription());
                    string item = currentRoom.GetItems();
                    Console.WriteLine($"\nIn the room there is a {item}." +
                        " Press Space to pick it up, or Enter to carry on...");
                    ConsoleKey PickupInput;

                    bool condition = true;
                    while (condition == true)
                    {
                        PickupInput = Console.ReadKey(true).Key;
                        if (PickupInput == ConsoleKey.Spacebar)
                        {
                            player.PickUpItem(item);
                            player.InventoryContents();
                            condition = false;
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





                Console.WriteLine("\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;

            }
        }
    }
}