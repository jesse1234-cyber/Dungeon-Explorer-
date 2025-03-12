using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;
        private List<string> monsters;

        public Room(string description, List<string> items, List<string> monsters)
        {
            this.description = description;
            this.items = items;
            this.monsters = monsters;
        }
        public List<string> GetItems()
        {
            return items;
        }
        public bool DeleteItem(string item)
        {
            return items.Remove(item);
        }
        public string ItemsContents()
        {
            return string.Join(", ", items);
        }
        public string MonstersContents()
        {
            return string.Join(", ", monsters);
        }
        public string GetDescription()
        {
            string roomText = "This is a " + description + " Room.";
            if (items.Count != 0)
            {
                roomText += "\nContains items:" + ItemsContents();
            }
            if (monsters.Count != 0)
            {
                roomText += "\nContains monsters:" + MonstersContents();
            }
            return roomText;
        }
    }
}