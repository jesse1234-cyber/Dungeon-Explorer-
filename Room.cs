namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        public string Item { get; private set; }

        public Room(string description, string item = "")
        {
            this._description = description;
            Item = item;
        }

        public string GetDescription()
        {
            return $"Room Description: {_description}";
        }
    }
}