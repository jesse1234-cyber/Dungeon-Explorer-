using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        public string RoomName { get; private set; }
        private List<string> _items;

        public Room(string roomName)
        {
            this.RoomName = roomName;
            this._items = new List<string>();
            _items.Add("torch");

            if (roomName == "Cell")
            this._description = "A dark cell with a bed.";
        }

        public string GetDescription()
        {
            return $"{RoomName}: {_description}";
        }

        public List<string> GetItems()
        {
            return _items;
        }
    }
}
