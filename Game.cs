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
            String usersName = Console.ReadLine(); ;
            this.player = new Player(usersName, 100, new List<Item>());
            this.currentRoom = new Room($"{usersName} you have woken up in a dark and damp room only lit up by lanterns hanging from the ceiling. " +
                $"\nVines and branches cover the walls of this unfamiliar location, and the sound of water drops echo." +
                $"\nPiles of bones and pools of bloods filled the room with the smell of death and countless amounts of " +
                $"\ndestroyed and shattered weapons filled the room with only a rusty dagger in intact.");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Item dagger = new Item("Dagger", "a rusty old weapon");
                Console.WriteLine("Would you Like to Check:" +
                 " \n-Health \n-Inventory \n-Items \n-Description \n-'Next' Room");
                while (true)
                {
                    string action = Console.ReadLine().ToLower();

                    if (action == "health")
                    {
                        Console.WriteLine($"{player.Name} your health is currently at {player.Health}/100");
                        Start();
                    }
                    else if (action == "inventory")
                    {
                        Console.WriteLine(player.InventoryContents());
                        Start();
                    }
                    else if (action == "items")
                    {
                        while (true)
                        {
                            Console.WriteLine("There is a dagger type 'yes' to pick it up");
                            string itemsAction = Console.ReadLine().ToLower();
                            if (itemsAction == "yes")
                            {
                                player.PickUpItem(dagger);
                                Console.WriteLine("This item has been added to your inventory");
                                Start();
                            }
                            else
                            {
                                Console.WriteLine("that was not 'yes'.");
                            }
                        }

                    }
                    else if (action == "description")

                    {
                        Console.WriteLine(currentRoom.GetDescription());
                        Start();
                    }
                    else if (action == "next")
                    {
                        Console.WriteLine("Currently you can not leave this room");
                        Start();
                    }
                    else
                    {
                        Console.WriteLine("Hey that wasnt a option please pick one of the options.");
                    }
                }





            }
        }
    }
}


