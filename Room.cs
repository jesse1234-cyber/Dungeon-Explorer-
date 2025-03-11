using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace DungeonExplorer
{
    public class Room
    {
        private string description; // Description of the room.  
        public string Name { get; set; }

        // Property used to get and set the room's description.
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value)) // Checks if the description is empty.
                {
                    Console.WriteLine("Room description cannot be empty.");
                }
                else
                {
                    description = value; // Sets the description.
                }
            }
        }


        private List<string> roomItems = new List<string>(); // List of items within the room.
        private List<string> roomPaths = new List<string>(); // List of paths to other rooms.
        private List<Enemy> roomEnemies = new List<Enemy>(); // List of enemies in the room.


        // Method used to add paths to the room.
        public void AddPath(string path)
        {
            if (!roomPaths.Contains(path))
            {
                roomPaths.Add(path);
            }
        }

        // Method used to add items to the room.
        public void AddItem(string item)
        {
            if (!roomItems.Contains(item))
            {
                roomItems.Add(item);
            }
        }

        // Method used to remove items from the room.
        public void RemoveItem(string item)
        {
            if (roomItems.Contains(item))
            {
                roomItems.Remove(item);
            }
        }
      
        // Method that returns the items that are in the room.
        public List<string> GetRoomItems()
        {
            return roomItems; // Return list of items in the room.
        }

        // Method that returns all the paths to other rooms.
        public List<string> GetRoomPaths()
        {
            return roomPaths;
        }

        public void AddEnemy(Enemy enemy)
        {
            roomEnemies.Add(enemy);
        }

        public List<Enemy> GetEnemies()
        {
            return roomEnemies;
        }

        // Method that returns the description of the room along with what items are inside of it.
        public void GetDescription(Room currentRoom)
        {
            List<string> paths = roomPaths.Where(path => path != currentRoom.Name).ToList();
            Console.WriteLine(description);
            if (roomItems.Count == 0)
            {
                Console.WriteLine("No items in the room.");
            }
            else
            {
                Console.WriteLine("There are the following items in the room: " + string.Join(", ", roomItems));
            }
            Console.WriteLine("Following paths in the room: " + string.Join(", ", paths));
        }
    }
}