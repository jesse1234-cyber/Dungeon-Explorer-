using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Weapon : InventoryItem
    {
        public Weapon(string inName)
        {
            sName = inName;
        }
    }
    public class Item : InventoryItem
    {
        public Item(string inName)
        {
            sName = inName;
        }
    }
}
