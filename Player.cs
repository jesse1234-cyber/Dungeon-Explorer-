using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        
        // Player inventory
        private readonly List<Item> inventory;
        
        // Limit inventory size to prevent hoarding
        private const int MAX_INVENTORY = 10;

        public Player(string name, int health)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Player needs a name!", nameof(name));
            
            if (health < 1)
                throw new ArgumentException("Health must be positive", nameof(health));
            
            Name = name;
            Health = health;
            inventory = new List<Item>();
        }

        public bool PickUpItem(Item item)
        {
            // Safety check
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Can't pick up nothing!");
            
            // Check inventory space
            if (inventory.Count >= MAX_INVENTORY)
                return false;
            
            // Add to inventory
            inventory.Add(item);
            return true;
        }
        
        public Item RemoveItem(string itemName)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentException("Need an item name", nameof(itemName));
            
            // Find and remove item
            var item = GetItem(itemName);
            if (item != null)
            {
                inventory.Remove(item);
                return item;
            }
            
            return null;
        }
        
        public Item GetItem(string itemName)
        {
            // Empty name check
            if (string.IsNullOrWhiteSpace(itemName))
                return null;
            
            // Case-insensitive search
            return inventory.FirstOrDefault(i => 
                i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
        
        public bool HasItem(string itemName)
        {
            return GetItem(itemName) != null;
        }
        
        public bool HasItems()
        {
            return inventory.Count > 0;
        }
        
        public IReadOnlyList<Item> GetInventory()
        {
            return inventory.AsReadOnly();
        }
        
        // Apply damage or healing
        public void ChangeHealth(int amount)
        {
            Health = Math.Max(0, Health + amount);
        }
        
        public bool IsAlive()
        {
            return Health > 0;
        }
        
        // Calculate inventory weight (for future use)
        public int GetInventoryCount()
        {
            return inventory.Count;
        }
        
        public int GetRemainingCapacity()
        {
            return MAX_INVENTORY - inventory.Count;
        }
    }
}
