using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public string Item {  get; set; } 

        public Room(string description, string item)
        {
            this.description = description;
            this.Item = item;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}