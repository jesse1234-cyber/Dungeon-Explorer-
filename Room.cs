using System; 
namespace DungeonExplorer
{
    public class Room
    {
        private string description;  // Private field for room description
        private string item;         // Private field for the item in the room (could be null if no item is present)

        // Constructor to initialize Room with a description and an item (optional)
        public Room(string description, string item = null)
        {
            this.description = description;
            this.item = item;  // If no item is passed, it will default to null
        }

        // Method to get the room's description
        public string GetDescription()
        {
            return description;
        }

        // Method to check if the room contains an item
        public bool HasItem(string itemName)
        {
            return item != null && item.Equals(itemName, StringComparison.OrdinalIgnoreCase);
        }

        // Method to remove the item from the room once it's picked up
        public void RemoveItem()
        {
            item = null;  // Remove the item once it's picked up
        }

        // Method to get the item in the room
        public string GetItem()
        {
            return item;
        }
    }
}