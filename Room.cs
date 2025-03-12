namespace DungeonExplorer
{
    public class Room
    {
        
        private string description;
        private List<string> items;
        private Dictionary<string, Room> connectedRooms; // connected rooms

        //initializes the room with a description.
        public Room(string description)
        {
            this.description = description;
            this.items = new List<string>();
            this.connectedRooms = new Dictionary<string, Room>();
        }
        public string GetDescription()
        {
            return description;
        }
        public void AddItem(string item)
        {
            items.Add(item);
        }
        public string ListItems()
        {
            return items.Count > 0 ? string.Join(", ", items) : "this room is empty.";
        }
        public void RemoveItem(string item)
        {
         if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} has been removed from this room");
            }
            else
            {
                Console.WriteLine($"{item} is not in this room");
            }
        }

        // adds a connected room in a specificed direction
        public void AddConnectedRoom(string direction, Room room)
        {
            connectedRooms[direction] = room;
        }
        // get a connected room in the specified direction
        public Room GetConnectedRoom(string direction)
        {
            return connectedRooms.ContainsKey(direction) ? connectedRooms[direction] : null;
        }
    }
}