using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player = new Player(); // Creates a new player entity.
        private Room room1 = new Room(); // Creates a new room entity.
        private Room room2 = new Room();
        private Room room3 = new Room();
        private Room currentRoom = new Room();
        private List<Room> rooms = new List<Room>();

        // Constructor which initializes the game with a player name and room description.
        public Game()
        {
            Console.WriteLine("You wake up after a long sleep, you can't remember anything except your name which is...");
            Console.Write("Enter your name: ");
            string new_name = Console.ReadLine(); // Get player name from input.
            Console.WriteLine($"That's it! {new_name} was your name!");
            Console.WriteLine("After getting your strength back, you stand up wondering where you are, not knowing what awaits you next.");
            Console.WriteLine("=============================================================================================================");
            player.Name = new_name; // Set player name.
            player.Health = 100; // Set player health.
            // Set room names
            room1.Name = "Room1";
            room2.Name = "Room2";
            room3.Name = "Room3";
            // Read room descriptions from a text file and set it.
            room1.Description = File.ReadAllText(@"Descriptions/room1.txt");
            room2.Description = File.ReadAllText(@"Descriptions/room2.txt");
            room3.Description = File.ReadAllText(@"Descriptions/room3.txt");
            // Adding items and paths to the rooms.
            room1.AddItem("Key");
            room1.AddPath("Room2");
            room1.AddPath("Room1");
            room2.AddItem("Sword");
            room2.AddPath("Room1");
            room2.AddPath("Room2");
            room2.AddPath("Room3");
            room3.AddItem("Healing Potion");
            room3.AddPath("Room2");
            room3.AddPath("Room3");
            currentRoom = room1;
            // Adding the rooms to the 'rooms' list.
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
        }

        // Method to start the game and handle user commands.
        public void Start()
        {
            bool description_checked = false;
            bool playing = true;
            while (playing)
            {
                // Display options to player.
                Console.WriteLine("Type help for a list of commands");
                Console.Write("Enter command: ");
                string user_input = Console.ReadLine().ToLower();
                // Help command displays other available commands to player.
                if (user_input == "help")
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("Status - displays the players' name, health and inventory.");
                    Console.WriteLine("Description - displays the description of the room.");
                    Console.WriteLine("Pick up [item name] - picks up an item from the room.");
                    Console.WriteLine("Go to [room name] - goes to specified room.");
                    Console.WriteLine("Quit - exits the game.");
                }
                else if (user_input == "status") // Display player status.
                {
                    Console.WriteLine("Name: " + player.Name);
                    Console.WriteLine("Health: " + player.Health);
                    Console.WriteLine("Inventory: " + player.InventoryContents());
                }
                else if (user_input == "description") // Display room description.
                {
                    currentRoom.GetDescription(currentRoom);
                    description_checked = true;
                }
                else if (user_input.StartsWith("pick up") && description_checked == true) // Pick up items.
                {
                    string pick = user_input.Substring(8).Trim();
                    if (!string.IsNullOrEmpty(pick))
                    {
                        player.PickUpItem(pick, currentRoom); // Calls the method to pick up the item.
                    }
                    else
                    {
                        Console.WriteLine("No item provided. Please specify which item you want to pick up.");
                    }
                }
                else if (user_input.StartsWith("go to") && description_checked == true)
                {
                    string go = user_input.Substring(6).Trim();
                    if (go.Equals("Room2", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!player.InventoryContents().Contains("Key"))
                        {
                            Console.WriteLine("The door is locked.");
                            go = "Room1";
                        }
                    }
                    Room targetRoom = rooms.Find(room => room.Name.Equals(go, StringComparison.OrdinalIgnoreCase));
                    if (targetRoom != null && currentRoom.GetRoomPaths().Any(path => path.Equals(go, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (currentRoom.Name != targetRoom.Name)
                        {
                            currentRoom = targetRoom;
                            Console.WriteLine($"You have entered {go}.");
                            description_checked = false;
                        }
                    }
                    else if (targetRoom == null)
                    {
                        Console.WriteLine("This room doesn't exist");
                    }
                    else if (!currentRoom.GetRoomPaths().Contains(go))
                    {
                        Console.WriteLine("No direct path leading to that room");
                    }
                }
                else if (user_input == "quit") // Quits the game.
                {
                    Console.WriteLine("Exiting....");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid command!"); // Displayed if an invalid command is displayed.
                }
            }
        }
    }
}