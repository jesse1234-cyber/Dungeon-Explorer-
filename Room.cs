namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item
        {
            get{  return item };
            set
            {
                item = string.IsNullOrEmpty(value) ? "NoName" : value;
            }}
        

        public Room(string description)
        {
            this.description = description;
            item = " ";
        }

        public string GetDescription()
        {
            return description;
        }
    }
}