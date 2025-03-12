using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public string RoomItem { get; set; }
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public Room(string description)
        {
            this.description = description;
        }

        public void CreateItem(string item)
        {
            RoomItem = item;
        }

        public string GetDescription()
        {
            return description;
        }

        public void RemoveItem()
        {
            RoomItem = null;
        }
    }
}

