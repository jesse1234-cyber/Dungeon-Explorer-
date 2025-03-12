namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item; // No nullable types

        public Room(string description, string item = "None") // Default item is "None"
        {
            this.description = description;
            this.item = item;
        }

        public string GetDescription() // Get method for inventory
        {
            return description;
        }

        public string GetItem()
        {
            return item;
        }

        public string TakeItem()
        {
            if (item != "None")
            {
                string takenItem = item;
                item = "None"; // No items left after pickup
                return takenItem;
            }
            return "No items left to take.";
        }
    }
}