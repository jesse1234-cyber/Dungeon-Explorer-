using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health = 100) // Default health = 100
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(string item)
        {
            if (inventory.Count == 0)
            {
                inventory.Add(item);
                Console.WriteLine($"You picked up: {item}");
            }
            else
            {
                Console.WriteLine("You can only carry one item at a time!");
            }
        }

        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "No items";
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name} | Health: {Health} | Inventory: {InventoryContents()}");
        }
    }
}