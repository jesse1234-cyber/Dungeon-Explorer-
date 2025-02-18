using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Add a dictionary for opposite directions
        private static readonly Dictionary<string, string> OppositeDirections = new Dictionary<string, string>
        {
            { "North", "South" },
            { "South", "North" },
            { "East", "West" },
            { "West", "East" }
        };

        // Player's Properties
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public List<string> Inventory { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public Room CurrentRoom { get; set; }

        // Player's constructor
        public Player(string name, int startX, int startY, Room currentRoom)
        {
            Name = name;
            MaxHealth = 100;
            Health = MaxHealth;
            Inventory = new List<string>();
            PlayerX = startX;
            PlayerY = startY;
            CurrentRoom = currentRoom;
        }

        // Method to add an item to inventory
        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        // Method to display player info
        public void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Health: " + Health + "/" + MaxHealth);
            Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
        }

        // Method to move to another room
        public void MoveToRoom(Room[,] Grid, int RoomCount)
        {
            Console.WriteLine("\nYou decide to move to another room, where do you want to go?");
            int end = CurrentRoom.Exits.Count;
            for (int i = 0; i < end; i++)
            {
                Console.WriteLine(i + 1 + ". " + CurrentRoom.Exits[i]);
            }
            Console.Write(end + 1 + ". Cancel\n: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice != (end + 1) && choice <= end)
            {
                // Create and move to the selected room
                RoomCount++;
                string roomID = "Room " + RoomCount;
                string direction = CurrentRoom.Exits[choice - 1];

                // Move the player
                switch (direction)
                {
                    case "North":
                        PlayerY--;
                        break;
                    case "South":
                        PlayerY++;
                        break;
                    case "East":
                        PlayerX++;
                        break;
                    case "West":
                        PlayerX--;
                        break;
                }

                if (Grid[PlayerX, PlayerY] != null)
                {
                    CurrentRoom = Grid[PlayerX, PlayerY];
                }

                else
                {
                    // Create the new room
                    Room newRoom = new Room(roomID, GameData.GetRandomRoomDescription(), RoomCount);

                    // Add exit to previous room
                    string oppositeDirection = OppositeDirections[direction];
                    newRoom.AddExit(oppositeDirection);

                    // Add new exits, but checks if there should already be one or not
                    bool doorAdded = false;
                    Random random = new Random();

                    while (!doorAdded)
                    {
                        foreach (string key in OppositeDirections.Keys)
                        {
                            int newX = PlayerX, newY = PlayerY;
                            string oppositeExit = "";

                            switch (key)
                            {
                                case "North": newY--; oppositeExit = "South"; break;
                                case "South": newY++; oppositeExit = "North"; break;
                                case "East": newX++; oppositeExit = "West"; break;
                                case "West": newX--; oppositeExit = "East"; break;
                            }

                            // Checks if the new room already has the exit
                            if (newRoom.Exits.Contains(key))
                                continue;

                            // Checks if the player is at the edge of the grid or if there is a room in the way
                            if (newX < 0 || newY < 0 || newX >= Grid.GetLength(1) || newY >= Grid.GetLength(0))
                                continue;
                            if (Grid[newX, newY] != null && !Grid[newX, newY].Exits.Contains(oppositeExit))
                                continue;

                            // Checks if there is a room in the way but it has an exit to the new room
                            if (Grid[newX, newY] != null && Grid[newX, newY].Exits.Contains(oppositeExit))
                            {
                                newRoom.AddExit(key);
                                continue;
                            }

                            // If it passes checks, attempt to add exit
                            int chance = random.Next(1, 5);
                            if (chance == 1)
                            {
                                newRoom.AddExit(key);
                                doorAdded = true;
                            }
                        }
                    }
                    // Add the new room to the grid
                    Grid[PlayerX, PlayerY] = newRoom;

                    // Set the new room as the current room
                    CurrentRoom = newRoom;

                    Console.WriteLine($"You move {direction} into {roomID}.");
                }
            }
        }

        // Method to pick up an item
        public void PickUpItem()
        {
            if (CurrentRoom.Items.Count > 0)
            {
                Console.WriteLine("\nYou decide to pick up an item, what do you pick up?");
                int end = CurrentRoom.Items.Count;
                for (int i = 0; i < end; i++)
                {
                    Console.WriteLine(i + 1 + ". " + CurrentRoom.Items[i]);
                }
                Console.Write(end + 1 + ". Cancel\n: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice != (end + 1) && choice <= end)
                {
                    AddItem(CurrentRoom.Items[choice - 1]);
                    CurrentRoom.Items.RemoveAt(choice - 1);
                }
            }
            else
            {
                Console.WriteLine("\nThere are no items to pick up in this room.");
            }
        }

        // Method to display a map of the grid
        public void DisplayMap(Room[,] Grid)
        {
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                for (int x = 0; x < Grid.GetLength(0); x++)
                {
                    if (Grid[x, y] != null)
                    {
                        if (x == PlayerX && y == PlayerY)
                        {
                            Console.Write("P ");
                        }
                        else
                        {
                            Console.Write("X ");
                        }
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}