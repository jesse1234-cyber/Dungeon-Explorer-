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
        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
                Console.WriteLine($"{Name} picked up: {item}");
            }
            else
            {
                Console.WriteLine("There is nothing to pick up.");
            }
        }
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Inventory is empty.";
        }
    }
}