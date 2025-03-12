using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    //set game class variables
    internal class Game
    {
        private Player player;
        private List<Room> allRooms;
        private int maxRooms;
        private int currentRoom;
        private string[] roomNames = { "Normal", "Treasure" };
        private string[] itemNames = { "+10HP", "Sword", "Sheild", "Magic Rune" };
        private string[] monsterNames = { "Zombie", "Skeleton", "Creeper", "Warden" };

        //initialize game class
        public Game(string name, int rooms)
        {
            player = new Player(name, 100);
            allRooms = new List<Room>();
            maxRooms = rooms;
            currentRoom = 0;

            Debug.Assert(0 < maxRooms, $"{maxRooms} rooms were generated");

            Random r = new Random();

            // generate a set ammount of random rooms
            for (int x = 0; x < rooms; x++)
            {

                string roomName = roomNames[r.Next(0, roomNames.Length - 1)];

                int rAmmount = 5;
                int rItemAmmount = r.Next(0, rAmmount);
                int rMonsterAmmount = r.Next(0, rAmmount);

                List<string> items = new List<string>();
                List<string> monsters = new List<string>();

                for (int y = 0; y< rItemAmmount; y++)
                {
                    items.Add(itemNames[r.Next(0, itemNames.Length - 1)]);
                }
                for (int z = 0; z < rMonsterAmmount; z++)
                {
                    monsters.Add(monsterNames[r.Next(0, monsterNames.Length - 1)]);
                }

                allRooms.Add(new Room(roomName, items, monsters));
            }
        }
        //main game logic
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nWhat would you like to do {player.Name}?\n1. View room's description\n2. Display your status\n3. Pick up an item\n4. Move room\n5. End Game");
                int.TryParse(Console.ReadLine(), out int choice);
                Console.WriteLine();
                if (choice == 1) // rooms description
                {
                    Console.WriteLine(allRooms[currentRoom].GetDescription());
                }
                else if (choice == 2) // players status
                {
                    Console.WriteLine($"Health: {player.Health}\nInventory: {player.InventoryContents()}");
                }
                else if (choice == 3) // pick up item from room
                {
                    List<string> items = allRooms[currentRoom].GetItems();
                    if (items.Count != 0)
                    {
                        Console.WriteLine($"There are {items.Count} items, which do you want to pick up: {allRooms[currentRoom].ItemsContents()}");
                        string selectedItem = Console.ReadLine();

                        bool found = false;
                        foreach (string item in items)
                        {
                            if (selectedItem.Equals(item, StringComparison.OrdinalIgnoreCase))
                            {
                                found = true;
                                allRooms[currentRoom].DeleteItem(item);
                                player.PickUpItem(item);
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Choose a valid option");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no items in this room");
                    }
                }
                else if (choice == 4) // move rooms
                {
                    string movementText = "You can";
                    if (maxRooms == 1)
                    {
                        movementText = "not move anywhere";
                        Console.WriteLine(movementText);
                    }
                    else
                    {
                        bool left = false;
                        bool right = false;
                        if (currentRoom != 0 && maxRooms != 1)
                        {
                            movementText += ", move to the left";
                            left = true;
                        }
                        if (currentRoom != maxRooms - 1 && maxRooms != 1)
                        {
                            movementText += ", move to the right";
                            right = true;
                        }

                        Console.WriteLine($"{movementText}, where do you want to go?");
                        string movement = Console.ReadLine();

                        if ("left".Equals(movement, StringComparison.OrdinalIgnoreCase) && left)
                        {
                            currentRoom -= 1;
                        }
                        else if ("right".Equals(movement, StringComparison.OrdinalIgnoreCase) && right)
                        {
                            currentRoom += 1;
                        }
                        else
                        {
                            Console.WriteLine("Choose a valid option");
                        }
                    }
                }
                else if (choice == 5) // end game
                {
                    playing = false;
                }
                else // for any invalid options
                {
                    Console.WriteLine("Choose a valid option");
                }
            }
        }
    }
}