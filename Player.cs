using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private Dictionary<string, int> inventory = new Dictionary<string, int>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (inventory.ContainsKey(item))
                {
                    inventory[item]++;
                }
                else
                {
                    inventory[item] = 1;
                }
                Console.WriteLine($"{Name} picked up: {item}");
            }
            else
            {
                Console.WriteLine("There is nothing to pick up.");
            }
        }

        public string InventoryContents()
        {
            if (inventory.Count == 0)
            {
                return "Inventory is empty.";
            }

            List<string> contents = new List<string>();
            foreach (var kvp in inventory)
            {
                contents.Add($"{kvp.Value}x {kvp.Key}");
            }
            return string.Join("\n", contents);
        }
    }
}