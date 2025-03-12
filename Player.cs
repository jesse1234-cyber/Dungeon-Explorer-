using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private string description;
        private int inventory;
        private int health;
        public string Name
        {
            get { return name; }
            set
            {
                name = string.IsNullOrEmpty(value) ? "NoName" : value;
            }
        }
public int Health
        {
            health = 100;
            get { return health; }
            set
            {
                health = (value >= 0 && value <= 100) ? value : 0;
            }
        }
        public int Inventory
        {
            get { return inventory; }
            set
            {
                inventory = (value >= 0 && value <= 1) ? value : 0;
            }
        }

        public Player(string name, int health, int inventory) 
        {
            Name = name;
            Health = health;
            Inventory = inventory;
        }
        public void PickUpItem(string item)
        {
           if (Inventory == null)
            {
               
                Console.WriteLine($"You picked up: {item}");

            }
            else
            {
                Console.WriteLine("Inventory is full! Can't carry anymore items.");
            }
        }
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name} | Health: {health} | Inventory: {inventory ?? "None"}");
            
        }
    }
}