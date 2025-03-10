using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player p;
        private Room r;

        public Game()
        {
            // Init player and room
            p = new Player("Adventurer", 10);
            r = new Room("a dimly lit chamber", "a rusty sword");
        }

        public void Start()
        {
            // Game start
            bool playing = true;
            Console.WriteLine("You are " + p.GetN() + "! in " + r.GetDescription());

            while (playing)
            {
                // Player action loop
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine(" - Look: See the room description");
                Console.WriteLine(" - Status: Check your health and inventory");
                Console.WriteLine(" - Get: Pick up an item");
                Console.WriteLine(" - Quit: Exit the game");

                string input = Console.ReadLine().ToLower();

                if (input == "l" || input == "look")
                {
                    Console.WriteLine(r.GetDescription());
                    if (r.GetItem() != null)
                    {
                        Console.WriteLine("You see: " + r.GetItem());
                    }
                }
                else if (input == "s" || input == "status")
                {
                    Console.WriteLine("Name: " + p.GetN() + ", HP: " + p.GetH() + ", Inventory: " + p.inv()); // Use getters!
                }
                else if (input == "g" || input == "get")
                {
                    string item = r.GetItem();
                    if (item != null)
                    {
                        p.pickup(item);
                        r.RemoveItem();
                    }
                    else
                    {
                        Console.WriteLine("There's nothing to get here.");
                    }
                }
                else if (input == "q" || input == "quit")
                {
                    playing = false;
        }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
