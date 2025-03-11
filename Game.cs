using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using Microsoft.Win32;

namespace DungeonExplorer
{
    internal class Game
    {
        public Player player { get; set; }
        public Room currentRoom { get; set; }
        public Testing test { get; set; }

        public Game(string userName)
        {
            //Instantiates the Player and currentRoom objects using the classes in Room.cs and Player.cs
            player = new Player(userName, 15);
            currentRoom = new Room("A kitchen. There is a knife resting on the counter.");
            test = new Testing();
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
                //The beginning of a switch case to check through all possible inputs from the player
               switch (input)
                {
                    //Case is used to check the potential inputs from the player.
                    case ConsoleKey.Q:
                        //Prints the players UserName and Stats
                        Console.WriteLine(player.Name + " Statistics" + "\n" + "Health " + player.Health);
                        break;
                    case ConsoleKey.F:
                        //Prints the players inventory
                        Console.WriteLine("Inventory:");
                        Console.WriteLine(player.InventoryContents());
                        break;
                    case ConsoleKey.E:
                        //Prints the description of the room.
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case ConsoleKey.G:
                        //If statement to check the Item variable has a value
                        if (item != "")
                        {
                            //Prints Picked Up and the item name, as well as adding the item to the inventory. 
                            Console.WriteLine("Picked Up " + item);
                            player.PickUpItem(item);
                            string Inventory = player.InventoryContents();
                            test.InventoryCheck(Inventory, item);
                            //Sets Item Variable to be blank
                            item = "";
                        }
                        else
                        {
                            //Prints if there is no Item
                            Console.WriteLine("There is no item to pick up");
                        }
                        break;
                    case ConsoleKey.R:
                        //Ends the play loop
                        playing = false;
                        break;
                    default:
                        //Prints if there is an incorrect input
                        Console.WriteLine("Please Input a valid control");
                        break;
                }
            }
        }
    }
}