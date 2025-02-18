using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Room
    {
        // Room's Properties
        public string RoomID { get; set; }
        public int RoomCount { get; set; }
        public string Description { get; set; }
        public List<string> Exits { get; set; }
        public List<string> Items { get; set; }
        public List<string> Enemies { get; set; }

        // Room's constructor
        public Room(string roomID, string description, int roomCount)
        {
            RoomID = roomID;
            RoomCount = roomCount;
            Description = description;
            Exits = new List<string>();
            Items = new List<string>();
            Enemies = new List<string>();
        }

        // Method to get the room's description
        public void GetDescription()
        {
            Console.WriteLine($"{RoomID}: {Description}");
            if (Items.Count > 0)
            {
                Console.WriteLine("Items here: " + string.Join(", ", Items));
            }
            if (Enemies.Count > 0)
            {
                Console.WriteLine("Enemies here: " + string.Join(", ", Enemies));
            }
            Console.WriteLine("Exits: " + string.Join(", ", Exits));
        }

        // Method to add an item to the room
        public void AddItem(string item)
        {
            Items.Add(item);
        }

        // Method to add an enemy to the room
        public void AddEnemy(string enemy)
        {
            Enemies.Add(enemy);
        }

        // Method to add an exit to the room
        public void AddExit(string exit)
        {
            Exits.Add(exit);
        }
    }
}