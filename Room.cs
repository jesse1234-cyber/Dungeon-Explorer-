using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        private static readonly List<string> RoomDescriptions = new List<string>
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"
        };
        public Room(string description)
        {
            Random random = new Random();
            int index = random.Next(RoomDescriptions.Count);
            this.description = RoomDescriptions[index];

        }

        public string GetDescription()
        {
            return description;
        }

        
    }
}