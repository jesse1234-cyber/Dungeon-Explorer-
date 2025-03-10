namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;  // Item the room contains (can be picked up by the player)
        public string Name { get; private set; }  // Name of the room for easy identification

        // Constructor that takes a name, description, and optional item
        public Room(string name, string description, string item = null)
        {
            Name = name;
            this.description = description;
            this.item = item;
        }

        // Get the room's description
        public string GetDescription()
        {
            return $"{Name}: {description}";
        }

        // Get the item in the room
        public string GetItem()
        {
            return item ?? "No items in this room.";
        }

        // Allow player to pick up the item (if there's an item in the room)
        public string PickUpItem()
        {
            if (item != null)
            {
                string pickedItem = item;
                item = null;  // Once picked up, the item is removed from the room
                return $"{pickedItem} picked up!";
            }
            else
            {
                return "There is nothing to pick up here.";
            }
        }

        // Check if the room contains an item
        public bool HasItem()
        {
            return item != null;
        }
    }
}
