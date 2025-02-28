namespace DungeonExplorer
{
    public class Room
    {
        private string roomDescription;
        private string roomName;

        public Room(string name, string description)
        {
            this.roomName = name;
            this.roomDescription = description;
        }

        public string GetDescription()
        {
            return this.roomDescription;
        }
    }
}