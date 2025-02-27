using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item
    {
        private bool Reagent;
        private bool Weapon;
        private string ItemDescription;
        public string ItemName;

        public Item(string itemName, string itemDescription, bool reagent, bool weapon)
        {
            this.Reagent = reagent;
            this.Weapon = weapon;
            this.ItemDescription = itemDescription
            ItemName = itemName
        }
    }
}