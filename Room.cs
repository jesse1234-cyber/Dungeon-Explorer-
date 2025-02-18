using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
            //Console.WriteLine($"Current Room: {description}");
        }

        public string GetDescription()
        {
            return description;
        }
    }
}