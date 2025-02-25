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
        public List<object> Enemies { get; set; }

        // Room's constructor
        public Room(string roomID, string description, int roomCount)
        {
            RoomID = roomID;
            RoomCount = roomCount;
            Description = description;
            Exits = new List<string>();
            Items = new List<string>();
            Enemies = new List<object>();
        }

        // Method to get the room's description
        public void GetDescription()
        {
            Console.WriteLine($"\n{RoomID}: {Description}\n");

            // Writes all the items in the room
            if (Items.Count > 0)
            {
                Console.WriteLine("Items here: " + string.Join(", ", Items) + "\n");
            }

            // Writes all the enemies in the room
            if (Enemies.Count > 0)
            {
                Console.Write("Enemies here: ");
                for (int i = 0; i < Enemies.Count; i++)
                {
                    // Access first element of each enemy item
                    List<object> enemy = (List<object>)Enemies[i];
                    Console.Write(enemy[0]);

                    // Add a comma and space if it's not the last enemy
                    if (i < Enemies.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("\n");
            }

            // Writes all the exits in the room
            Console.WriteLine("Exits: " + string.Join(", ", Exits) + "\n");
        }

        // Method to add an item to the room
        public void AddItem(string item)
        {
            Items.Add(item);
        }

        // Method to add an enemy to the room
        public void AddEnemy(List<object> enemy)
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
