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
            //Instantiates the Player and currentRoom objects using the classes in Room.cs and Player.cs
            player = new Player(userName, 15);
            currentRoom = new Room("A kitchen. There is a knife resting on the counter.");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            //Displays the controls to the player
            Console.WriteLine("Q - Show Stats.  F - Show Inventory.  E - Show Room Description. G - Pick up Item. R - Quit Game.");
            //Establishes the Item Variable so the player can pick it up, it is established here to stop the same item being grabbed more than once. 
            string item = "Knife";
            //The loop of game logic
            while (playing)
            {
                //Reads a key input and stores it as variable "input"
                var input = Console.ReadKey(true).Key;
                //The start of an If statement that checks for each Key on the control scheme and provides its output.
                if (input == ConsoleKey.Q)
                {
                    //Displays player Name, and Health
                    Console.WriteLine(player.Name + " Statistics:" + "\n" + "Health: " + player.Health);
                }
                else if (input == ConsoleKey.F)
                {
                    //Prints players current inventory 
                    Console.WriteLine("Inventory:");
                    Console.WriteLine(player.InventoryContents());
                }
                else if (input == ConsoleKey.E)
                {
                    //Prints room description
                    Console.WriteLine(currentRoom.GetDescription());
                }
                else if (input == ConsoleKey.G)
                {
                    //Checks if the Item Variable has an item in it or is empty
                    if (item != "")
                    {
                        //If there is an item, adds it to inventory and sets the item variable to empty. 
                        Console.WriteLine("Picked up " + item);
                        player.PickUpItem(item);
                        item = "";
                    }
                    else
                    {
                        //Prints if there is nothing stored in Item Variable.
                        Console.WriteLine("There is no item to pick up.");
                    }
                }
                else if (input == ConsoleKey.R)
                {
                    //Quits the gameplay loop
                    playing = false;
                }
                else
                {
                    //Prints if a Non-Valid input is used 
                    Console.WriteLine("Please input a valid control");
                }
            }
        }
    }
}