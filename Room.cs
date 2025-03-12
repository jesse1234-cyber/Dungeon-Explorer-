using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;

        public Room(string description, List<string> items)
        {
            this.description = description;
            this.items = items;
        }

        public string GetDescription()
        {
            if (items.Count == 0)
            {
                description = "The room is cold and musty, a rusted iron cage sits in the corner, empty but unsettling. There is nothing of note here, what will you do?";
            }
            else
            {
                description = "The room is cold and musty, a rusted iron cage sits in the corner, empty but unsettling. There is a" + string.Join(",", items) + "on the floor";
            }
            return description;
        }

        public void RemoveItems(string item)
        {
            items.Remove(item);
        }

        public List<string> GetItems()
        {
            return items;
        }
    }

    
}