using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Entity
    {
      
        private List<Item> inventory = new List<Item>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(Item item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}