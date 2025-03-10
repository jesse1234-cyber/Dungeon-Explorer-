using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        // Constructor to initialize the player's name and health
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Method to pick up an item and add it to the inventory
        public string PickUpItem(string item)
        {
            inventory.Add(item);  // Adds the item to the player's inventory
            return $"{item} added to inventory."; // Return message instead of printing directly
        }

        // Method to get inventory contents
        public string InventoryContents()
        {
            return inventory.Count == 0 ? "No items in inventory." : string.Join(", ", inventory);
        }

        // Method to change the player's health
        public string ChangeHealth(int amount)
        {
            Health += amount;
            if (Health < 0) Health = 0;  // Ensure health doesn't drop below 0
            return $"Health changed by {amount}. Current health: {Health}";
        }
    }
}
