using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Security.Cryptography;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player

            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();

            player = new Player(name, 10);
            currentRoom = new Room("The Room is dark and misty");


        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            bool opened = false;
            
            List<string> visitedRoom = new List<string>(); // Initializing a list of visited rooms
            List<string> ItemList = new List<string>{"A Sword", "A Bow", "An Axe", "A Key" }; // Initializing a list of items
            while (playing)
            {
                // Code your playing logic here                
                
                // Generating a random number to select a random index from the ItemList
                Random rnd = new Random();
                int index = rnd.Next(ItemList.Count);
                if (ItemList.Count == 0) // Checking to see if the list is empty, if so a blank space is added to the list to prevent an error
                {
                    ItemList.Add("");
                }

                else
                {

                }

                string ChosenItem = ItemList[index];

                Console.WriteLine("\nWould You Like to:\n 1) Look Around \n 2) Open the Chest \n 3) Check Your Current Status \n 4) Move Onto The Next Room \n 5) Exit\n"); // Options for the user to progress

                string ans = Console.ReadLine();

                if (ans == "1") // Provides the room description
                {
                    Console.WriteLine("");
                    Console.Write(currentRoom.GetDescription());
                    Console.WriteLine("");
                }

                else if (ans == "2" ) // Will open the chest in the room
                {
                    if (opened == false) // Checking to see if the chest for that room has already been opened
                    {
                        if (ChosenItem == "") // Checking to see if ItemList is empty
                        {
                            Console.WriteLine("The Chest Is Empty !!! ");
                        }

                        else // If the ItemList is not empty then item is added to inventory
                        {
                            player.PickUpItem(ChosenItem);
                            Console.WriteLine($"\n {ChosenItem} has been added to your inventory.");
                            ItemList.Remove(ChosenItem);
                            opened = true;
                        }
                        
                    }

                    else if (opened == true) // If the chest has been opened
                    {
                        Console.WriteLine($"\n This Rooms Chest Has Already Been Opened! ");
                    }
                }

                else if (ans == "3") // If input is "3" then the inventory and current health is displayed
                {   
                    if (player.InventoryContents() == "") // Checking to see if the inventory is empty
                    {
                        Console.WriteLine("Your inventory is currently empty !!! ");
                    }

                    else
                    {
                        Console.WriteLine("Your inventory Currently Contains of:");
                        Console.Write(player.InventoryContents()); 
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Your current health is: ");
                    Console.Write(player.GetHealth());
                    Console.WriteLine("");
                }

                else if (ans == "4") // If the input is "4" then the player will advance to another room
                {
                    // currentRoom.RandRoom();
                    string newDescription = currentRoom.RandRoom(visitedRoom); 

                    if (newDescription == "") // If the returned value is blank, then every room has been visited already
                    {
                        Console.WriteLine("All rooms have been visited ");
                    }
                    else // Otherwise the new room is visited
                    {
                        currentRoom = new Room(newDescription);
                        Console.Write(newDescription);
                        visitedRoom.Add(newDescription); // Adding the current description to the visitedRoom list to ensure the same room is not revisited
                        opened = false;
                    }
                }

                else if (ans == "5") // Exiting condition
                {
                    Environment.Exit(0);
                }

                else // Error checking so if any value other than 1,2,3,4 or 5 is entered then a message is diplayed
                {
                    Console.WriteLine("Input Is Invalid !!!");
                }


                
            }
        }
    }
}
