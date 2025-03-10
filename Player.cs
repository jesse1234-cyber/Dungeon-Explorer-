using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Adds an item to the player's inventory.
        /// </summary>
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// Displays the player's inventory.
        /// </summary>
        public string InventoryContents()
        {
            return inventory.Count == 0 ? "No items in inventory." : string.Join(", ", inventory);
        }

        /// <summary>
        /// Changes the player's health.
        /// </summary>
        public void ChangeHealth(int amount)
        {
            Health += amount;
            if (Health < 0) Health = 0;  // Ensure health doesn't drop below 0
            Console.WriteLine($"Health changed by {amount}. Current health: {Health}");
        }
    }
}
