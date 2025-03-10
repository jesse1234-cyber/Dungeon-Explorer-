using System;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private List<Room> rooms;
        private int currentRoomIndex;

        public Game()
        {
            // Initialise the player
            player = new Player("Adventurer", 100);

            // Initialise the rooms
            rooms = new List<Room>
    {
        new Room("Dungeon Entrance",
                 "You are at the entrance of the dungeon.",
                 "A rusty key lies on the ground.",
                 "rusty key"),
        new Room("Abandoned Armoury",
                 "You enter an abandoned armoury.",
                 "An iron sword rests on a table.",
                 "iron sword"),
        new Room("Ranger's Rest",
                 "You find yourself in a ranger's resting place.",
                 "A longbow leans against the wall.",
                 "longbow")
    };

            // Start in the first room (Dungeon Entrance)
            currentRoomIndex = 0;
        }
        
        public void Start()
        {
            Console.WriteLine("The Dungeon awaits, Adventurer.");
            Console.WriteLine("Type 'look' to view the room, 'status' to check your health and inventory, 'pickup' to pick up an item, 'north' to go north, 'south' to go south, or 'exit' to quit.");
            
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nYou are in the {rooms[currentRoomIndex].Name}.");
                Console.Write("What would you like to do? ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "look":
                        Console.WriteLine(rooms[currentRoomIndex].GetDescription());
                        break;

                    case "status":
                        Console.WriteLine($"Health: {player.Health}, Inventory: {player.InventoryContents()}");
                        break;
                    
                    case "pickup":
                        string item = rooms[currentRoomIndex].GetItem();
                        if (item != null)
                        {
                            player.PickUpItem(item);
                            Console.WriteLine($"You picked up the {item}.");
                            rooms[currentRoomIndex].RemoveItem(); // Remove the item from the room
                        }
                        else
                        {
                            Console.WriteLine("There is nothing to pick up here.");
                        }
                        break;

                    case "north":
                        if (currentRoomIndex < rooms.Count - 1)
                        {
                            currentRoomIndex++;
                            Console.WriteLine("You move north.");
                        }
                        else
                        {
                            Console.WriteLine("You cannot go further north.");
                        }
                        break;

                    case "south":
                        if (currentRoomIndex > 0)
                        {
                            currentRoomIndex--;
                            Console.WriteLine("You move south.");
                        }
                        else
                        {
                            Console.WriteLine("You cannot go further south.");
                        }
                        break;

                    case "exit":
                        Console.WriteLine("Farewell, Adventurer.");
                        Environment.Exit(0);
                        break;
                        

                    default:
                        Console.WriteLine("Invalid command. Try 'look', 'status', 'pickup', 'north', 'south', or 'exit'.");
                        break;
                }
            }
        }
    }
}