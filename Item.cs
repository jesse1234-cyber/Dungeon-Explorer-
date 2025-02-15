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

        public Item(int itemID, string name, string description)
        {
            ItemID = itemID;
            Name = name;
            Description = description;
        }
    }
}
