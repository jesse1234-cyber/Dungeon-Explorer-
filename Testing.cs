using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        public void InventoryCheck(string Inventory, string Item)
        {
            Debug.Assert(Inventory.Contains(Item), "Item has not been picked up");
            Console.WriteLine("Item has been picked up!");
        }
    }
}