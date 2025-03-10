namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; private set; }
        private string baseDescription; // Base description without the item
        private string itemDescription; // Description of the item
        private string item;

        public Room(string name, string baseDescription, string itemDescription, string item)
        {
            Name = name;
            this.baseDescription = baseDescription;
            this.itemDescription = itemDescription;
            this.item = item;
        }

        public string GetDescription()
        {
            // If the item is still in the room, include it in the description
            if (item != null)
            {
                return $"{baseDescription} {itemDescription}";
            }
            // Otherwise, return only the base description
            return baseDescription;
        }

        public string GetItem()
        {
            return item;
        }

        public void RemoveItem()
        {
            item = null; // Remove the item from the room
        }
    }
}