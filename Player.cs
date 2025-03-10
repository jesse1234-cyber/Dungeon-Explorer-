using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player in the dungeon game.
    /// Contains the player's name, health, and inventory, along with methods to interact with them.
    /// </summary>
    public class Player
    {
        public string Name { get; private set; } // Player's name (cannot be modified after creation)
        public int Health { get; private set; } // Player's health (cannot be modified directly after creation)
        private List<string> _inventory; // A private list to store the player's inventory items

        /// <summary>
        /// Initializes a new player with a specified name and health.
        /// If the name is null or empty, it defaults to "DefaultName".
        /// If the health is less than or equal to zero, it defaults to 100.
        /// </summary>
        /// <param name="name">The player's name.</param>
        /// <param name="health">The player's health.</param>
        public Player(string name, int health)
        {
            // If the name is invalid (null or empty), assign a default name
            Name = string.IsNullOrWhiteSpace(name) ? "DefaultName" : name;

            // If health is invalid (less than or equal to zero), assign default health of 100
            Health = health > 0 ? health : 100;

            // Initialize an empty inventory
            _inventory = new List<string>();
        }

        /// <summary>
        /// Adds an item to the player's inventory.
        /// If the item is not null or empty, it will be added to the inventory list.
        /// </summary>
        /// <param name="item">The item to be added to the inventory.</param>
        public void PickUpItem(string item)
        {
            // Only add the item if it's not null or empty
            if (!string.IsNullOrEmpty(item))
            {
                _inventory.Add(item); // Add the item to the inventory list
                Console.WriteLine($"{item} added to your inventory."); // Inform the player
            }
        }

        /// <summary>
        /// Returns a string representation of the player's inventory contents.
        /// If the inventory is empty, it returns "Empty".
        /// </summary>
        /// <returns>A string of comma-separated inventory items or "Empty" if no items are in the inventory.</returns>
        public string InventoryContents()
        {
            // If the inventory has items, join them into a comma-separated string, otherwise return "Empty"
            return _inventory.Count > 0 ? string.Join(", ", _inventory) : "Empty";
        }
    }
}
