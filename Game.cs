using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using Microsoft.Win32;

namespace DungeonExplorer
{
    internal class Game
    {
        public Player player { get; set; }
        public Room currentRoom { get; set; }

        public Game(string userName)
        {
            player = new Player(userName, 15);
            currentRoom = new Room("A kitchen. There is a knife resting on the counter.");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine("Q - Show Stats.  F - Show Inventory.  E - Show Room Description. G - Pick up Item. R - Quit Game.");
            string item = "Knife";
            while (playing)
            {
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Q)
                {
                    Console.WriteLine(player.Name + " Statistics:" + "\n" + "Health: " + player.Health);
                }
                else if (input == ConsoleKey.F)
                {
                    Console.WriteLine("Inventory:");
                    Console.WriteLine(player.InventoryContents());
                }
                else if (input == ConsoleKey.E)
                {
                    Console.WriteLine(currentRoom.GetDescription());
                }
                else if (input == ConsoleKey.G)
                {
                    if (item != "")
                    {
                        Console.WriteLine("Picked up " + item);
                        player.PickUpItem(item);
                        item = "";
                    }
                    else
                    {
                        Console.WriteLine("There is no item to pick up.");
                    }
                }
                else if (input == ConsoleKey.R)
                {
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid control");
                }
            }
        }
    }
}