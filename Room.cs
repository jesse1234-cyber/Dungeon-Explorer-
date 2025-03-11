using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a single room in the game with a description and possibly an itme
    /// </summary>
    public class Room
    {
        private string _description;
        public string RoomName { get; private set; }
        public Room Left { get; set; }  
        public Room Right { get; set; }
        private List<string> _items;

        public Room(string roomName)
        {
            this.RoomName = roomName;
            this._items = new List<string>();


            if (roomName == "Cell")
            {
                _items.Add("torch");  // Adds a torch to the cell room
                 this._description = "A dark cell with a bed.";  // Cell's room description
            }
            else if (roomName == "Room of Doom")
            {
                this._description = "A huge room with bats."; // Room of doom's description
            }
        }

        public Room(string roomName, string v) : this(roomName)
        {
        }

        /// <summary>
        /// Returns the room's description
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return $"{RoomName}: {_description}";
        }

        /// <summary>
        /// Returns the items
        /// </summary>
        /// <returns></returns>
        public List<string> GetItems()
        {
            return _items;
        }

        public void AddItem(string item)
        {
            _items.Add(item);
        }

        public bool ContainsItem(string item)
        {
            return _items.Contains(item);
        }
    }
}
