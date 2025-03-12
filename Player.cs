using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get;  set; }
        public int Health { get;  set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void addItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item} added to inventory.");
        }

        public void showInv()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Empty"); 
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (string item in inventory)
                {
                    Console.WriteLine($"-{item}");
                } 
            }
        }
        
        public void ShowHealth()
        {
            Console.WriteLine($"Your health is {Health}.");
        }
    }
}