using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Media;
using System.Runtime.Remoting.Messaging;
using DungeonExplorer;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Room> rooms;
        private string input;
        private bool playing;

      // Allows for the random function to be used in my code for random selection of items
        private Random random;
        private List<string> items;

        public Game()
        {
            Console.WriteLine("Please enter player name: ");
            string name = Console.ReadLine();
            player = new Player(name, 100);      // Logs player name and the health value
            random = new Random();
            items = new List<string> { "Sword", "Compass", "Helmet", "Key", "Map", "Shield" };
            rooms = new List<Room>();
            
            //Adding rooms with an added parameter of random selection from the list of items
            {
                rooms.Add(new Room("You are in the game room.", items[random.Next(items.Count)]));
                rooms.Add(new Room("You are in a ritual chamber.", items[random.Next(items.Count)]));
                rooms.Add(new Room("You are in a prison cell.", items[random.Next(items.Count)]));
                rooms.Add(new Room("You are in the armoury.", items[random.Next(items.Count)]));
                rooms.Add(new Room("You are in the Throne room.", items[random.Next(items.Count)]));

            }

        }
        public void Start()
        {
            bool playing = true;
            while (playing)
                // Using the try catch block to catch any errors that may occur during my game
                try
                {
                    Console.WriteLine($"Player 1: {player.Name}");

                    Console.WriteLine($"Health Points: {player.Health}");
                    Console.WriteLine("Do you want to continue playing? (Yes|No)");
                    string continueinput = Console.ReadLine();
                    if (continueinput.ToLower() == "no")
                    {
                        playing = false;
                        Console.WriteLine("Game ended.");
                    }
                    if (continueinput.ToLower() == "yes")
                    {

                        Console.WriteLine("Which room do you want to go to? (1-5)");
                        string input2 = Console.ReadLine();

                        //Using the if else statement to allow the player to choose which room to go to

                        if (input2 == "1")
                        {
                            currentRoom = rooms[0];
                            currentRoom.Item = items[random.Next(items.Count)];
                            Console.WriteLine($"There is a {currentRoom.Item} in the room.");
                            Console.WriteLine("Do you want to pick up this item yes|no?");
                            string input3 = Console.ReadLine();
                            if (input3.ToLower() == "yes")
                            {
                                player.PickUpItem(currentRoom.Item);
                                Console.WriteLine($"You picked up the {currentRoom.Item}.");
                            }
                            else
                            {
                                Console.WriteLine("You did not pick up the item.");
                            }
                            Console.WriteLine($"Current Room: {currentRoom.GetDescription()}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");


                        }
                        if (input2 == "2")
                        {
                            currentRoom = rooms[1];
                            currentRoom.Item = items[random.Next(items.Count)];
                            Console.WriteLine($"There is a {currentRoom.Item} in the room.");
                            Console.WriteLine("Do you want to pick up this item yes|no?");
                            string input3 = Console.ReadLine();
                            if (input3.ToLower() == "yes")
                            {

                                // Using and calling the PickUpItem method to add the item to the player's inventory

                                player.PickUpItem(currentRoom.Item);
                                Console.WriteLine($"You picked up the {currentRoom.Item}.");
                            }
                            else
                            {
                                Console.WriteLine("You did not pick up the item.");
                            }

                            // using and calling the GetDescription method to get the description of the current room

                            Console.WriteLine($"Current Room: {currentRoom.GetDescription()}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        }
                        if (input2 == "3")
                        {
                            currentRoom = rooms[2];
                            currentRoom.Item = items[random.Next(items.Count)];
                            Console.WriteLine($"There is a {currentRoom.Item} in the room.");
                            Console.WriteLine("Do you want to pick up this item yes|no?");
                            string input3 = Console.ReadLine();
                            if (input3.ToLower() == "yes")
                            {
                                player.PickUpItem(currentRoom.Item);
                                Console.WriteLine($"You picked up the {currentRoom.Item}.");
                            }
                            else
                            {
                                Console.WriteLine("You did not pick up the item.");
                            }
                            Console.WriteLine($"Current Room: {currentRoom.GetDescription()}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        }
                        if (input2 == "4")
                        {
                            currentRoom = rooms[3];
                            currentRoom.Item = items[random.Next(items.Count)];
                            Console.WriteLine($"There is a {currentRoom.Item} in the room.");
                            Console.WriteLine("Do you want to pick up this item yes|no?");

                            string input3 = Console.ReadLine();
                                Console.WriteLine("Invalid input. Please try again.");
                            if (input3.ToLower() == "yes")
                            {
                                player.PickUpItem(currentRoom.Item);
                                Console.WriteLine($"You picked up the {currentRoom.Item}.");
                            }
                            else if (input3.ToLower() == "no")
                            {
                                Console.WriteLine("You did not pick up the item.");
                            }
                            Console.WriteLine($"Current Room: {currentRoom.GetDescription()}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        }
                        if (input2 == "5")
                        {
                            currentRoom = rooms[4];
                            currentRoom.Item = items[random.Next(items.Count)];
                            Console.WriteLine($"There is a {currentRoom.Item} in the room.");
                            Console.WriteLine("Do you want to pick up this item yes|no?");
                            string input3 = Console.ReadLine();
                            if (input3.ToLower() == "yes")
                            {
                                player.PickUpItem(currentRoom.Item);
                                Console.WriteLine($"You picked up the {currentRoom.Item}.");
                            }
                            else
                            {
                                Console.WriteLine("You did not pick up the item.");
                            }
                            Console.WriteLine($"Current Room: {currentRoom.GetDescription()}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        }
                    }

                    //Using catch and ApplicationException to catch any exceptions that may occur during the game

                    
                }
                catch 
                {
                    
                    Console.WriteLine("Error");

                }
        }
    }
}
                