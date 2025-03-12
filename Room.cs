namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;
        
        public void pickItem(string item)
        {
           if (item =! null)
            {
               
                Console.WriteLine($"You picked up: {item}");

            }
           
        }

        public Room(string description)
        {
            this.description = description;
            this.item = item
        }

        public string GetDescription()
        {
            return description;
        }
    }
}