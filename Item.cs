using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        private int ItemID { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }

        // Item Constructor
        // Arguments:
        // itemID - the ID of the item
        // name - the name of the item
        // description - the description of the item
        public Item(int itemID, string name, string description)
        {
            // Set the item ID, name and description
            ItemID = itemID;
            Name = name;
            Description = description;
        }
    }
}
