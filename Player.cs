using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; } // player name
        public int Health { get; private set; } // player health
        private List<string> inventory = new List<string>(); // player inventory

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item} added to your inventory.");
        }
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Your inventory is empty.";
        }

        // decrease the players health
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"you took {damage} damage. your current health is {Health}");
        }
        // heals the player
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"you have healed {amount} health. your current health is {Health}");
        }
    }
}