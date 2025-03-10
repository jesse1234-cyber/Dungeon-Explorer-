using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            Console.Write("Please enter your name: ");
            String usersName = Console.ReadLine();
            this.player = new Player(usersName, 100, new List<Item>());
            this.currentRoom = new Room($"{usersName} you have woken up in a dark and damp room only lit up by lanterns hanging from the ceiling. " +
                $"\nVines and branches cover the walls of this unfamiliar location, and the sound of water drops echo." +
                $"\nPiles of bones and pools of bloods filled the room with the smell of death and countless amounts of " +
                $"\ndestroyed and shattered weapons filled the room with only a rusty dagger in intact.There is also what looks like a key next to it ");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            //creates item dagger
            bool playing = true;
            Item dagger = new Item("Dagger", "a rusty old weapon");
            Item gold_key = new Item("Gold Key", "a two prong key");

            while (playing)
            {
                
                Console.WriteLine("Would you Like to Check:" +
                 " \n-Health \n-Inventory \n-Items \n-Description \n-'Next' Room \n-End");
                while (true)
                {
                    string action = Console.ReadLine().ToLower();

                    //shows players health to user
                    if (action == "health")
                    {
                        Console.WriteLine($"{player.Name} your health is currently at {player.Health}/100");
                        Start();
                    }
                    //shows contents of inventory to user
                    else if (action == "inventory")
                    {
                        Console.WriteLine(player.InventoryContents());
                        Start();
                    }

                    //allows user to pick up items if they are available
                    else if (action == "items")
                    {
                        while (true)
                        {
                            Console.WriteLine("There is a dagger and a key type 'yes' to pick it up");
                            string itemsAction = Console.ReadLine().ToLower();
                            if (itemsAction == "yes")
                            {
                                player.PickUpItem(dagger);
                                player.PickUpItem(gold_key);
                                Console.WriteLine("This item has been added to your inventory");
                                Start();
                            }
                            else
                            {
                                Console.WriteLine("that was not 'yes'.");
                            }
                        }

                    // gives usr description of the current room
                    }
                    else if (action == "description")

                    {
                        Console.WriteLine(currentRoom.GetDescription());
                        Start();
                    }

                    //allows user to go to next room
                    else if (action == "next")
                    {
                        Console.WriteLine("Currently you can not leave this room");
                        Start();
                    }

                    //allows user to end program 
                    else if (action == "end")
                    {
                        playing = false;
                        break;

                    }

                    //prompts user to put a correct input 
                    else
                    {
                        Console.WriteLine("Hey that wasnt a option please pick one of the options.");
                    }
                }





            }
        }
    }
}


