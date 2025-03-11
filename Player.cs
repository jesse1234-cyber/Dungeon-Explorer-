using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Player
    {
        private string _name;
        private string _description;
        private int _inventory;
        private int _health;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = string.IsNullOrEmpty(value) ? "NoName" : value;
            }
        }
public int Health
        {
            _health = 100;
            get { return _health; }
            set
            {
                _health = (value >= 0 && value <= 100) ? value : 0;
            }
        }
        public int Inventory
        {
            get { return _inventory; }
            set
            {
                _inventory = (value >= 0 && value <= 1) ? value : 0;
            }
        }

        public Player(string _name, int _health, int _inventory) 
        {
            Name = _name;
            Health = _health;
            Inventory = _inventory;
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
            Console.WriteLine($"Player: {Name} | Health: {-health} | Inventory: {_inventory ?? "None"}");
            
        }
    }
}