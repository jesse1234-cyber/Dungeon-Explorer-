namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public string Item { get; set; }

        public Room(string description, string item)
        {
            // Parameter to assign the description and item to the fields
            this.description = description;
            this.Item = item;
        }

        public string GetDescription()
        {  
            return description;
        }
    }
}