namespace DungeonExplorer
{
    public class Room
    {
        // Git test 
        private string description;

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