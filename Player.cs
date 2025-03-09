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
        public void PickUpItem(string item)
        {
            inventory.Add(item);  // Adds the item to the player's inventory
            Console.WriteLine($"{item} added to inventory.");
        }

        // Method to display inventory contents
        public string InventoryContents()
        {
            return inventory.Count == 0 ? "No items in inventory." : string.Join(", ", inventory);
        }

        // Method to change the player's health (for example, when they take damage or heal)
        public void ChangeHealth(int amount)
        {
            Health += amount;
            if (Health < 0) Health = 0;  // Ensure health doesn't drop below 0
            Console.WriteLine($"Health changed by {amount}. Current health: {Health}");
        }
    }
}