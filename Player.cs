using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        
        private List<ItemType> _inventory = new List<ItemType>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }
        
        public void PickUpItem(ItemType item)
        {
            _inventory.Add(item);
        }

        public void UseItem(ItemType item)
        {
            
        }
        
        public void RemoveHealth(int amount)
        {
            // TODO: Ensure does not go below 0
        }

        public void AddHealth(int amount)
        {
            // TODO: Ensure does not go above 100
        }

        public void GiveBadLuck()
        {
            
        }
        
        public void StealItem()
        {
            
        }
    }
}