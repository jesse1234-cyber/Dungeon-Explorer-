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
            currentRoom = new Room("The area is dark and misty.");


        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            bool opened = false;
            List<string> ItemList = new List<string>{"A Sword", "A Bow", "An Axe", "A Key" };
            while (playing)
            {
                // Code your playing logic here                

                Random rnd = new Random();
                int index = rnd.Next(ItemList.Count);
                string ChosenItem = ItemList[index];



                Console.WriteLine("\nWould You Like to:\n 1) Look Around \n 2) Open the Chest \n 3) Check Your Current Status \n 4) Exit\n");

                string ans = Console.ReadLine();

                if (ans == "1")
                {
                    Console.WriteLine("");
                    Console.Write(currentRoom.GetDescription());
                    Console.WriteLine("");
                }

                else if (ans == "2" )
                {
                    if (opened == false)
                    {
                        player.PickUpItem(ChosenItem);
                        Console.WriteLine($"\n {ChosenItem} has been added to your inventory.");
                        ItemList.Remove(ChosenItem);
                        opened = true;
                    }

                    else if (opened == true)
                    {
                        Console.WriteLine($"\n This Rooms Chest Has Already Been Opened! ");
                    }
                }

                else if (ans == "3")
                {   
                    if (player.InventoryContents() == "")
                    {
                        Console.WriteLine("Your Inventory Is Currently Empty");
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

                else if (ans == "4")
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Input Is Invalid !!!");
                }


                
            }
        }
    }
}