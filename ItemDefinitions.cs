using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Simple class for inventory items, which are kept in the players inventory or as 'FloorItems' in rooms.
    /// Has simple overloads for if there is no items present but they want to remain in the inventory, for instance key items.
    /// 
    /// </summary>
    public class InventoryItem
    {
        public int maxNoOfItem { get; set; }
        public int noOfItem { get; set; }
        public string sName { get; set; }
        public string sDescription;
        public InventoryItem(string name, int maxNoOfItem)
        {
            sDescription = "PLACEHOLDER";
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = 1;
        }
        public InventoryItem(string name, int maxNoOfItem, int noOfItem)
        {
            sDescription = "A common food item in hyrule. eating will restore health!";
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = noOfItem;
        }
    }

}
