using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Private fields
        public string Name { get; private set; }  // Read-only property
        public int Health { get; private set; }   // Read-only property
        private List<string> inventory = new List<string>();

        // Constructor to initialize Player object
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Method to add item to the inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        // Method to return the inventory contents as a string
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Nothing yet";
        }

        // Method to simulate taking damage (optional future feature)
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;  // Ensure health doesn't go below 0
        }
    }
}