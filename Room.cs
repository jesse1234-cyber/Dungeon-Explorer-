namespace DungeonExplorer
{
    public class Room
    {
        private string description; // Each object for this class would be each room. How would the descriptions change?

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}