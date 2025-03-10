using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> _inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
            _inventory.Add("Sword");
        }

        public void PickUpItem(string item)
        {
             // add item to player inventory array
            _inventory.Add(item);
        }

        public void InventoryContents()
        {
             // display player inventory
            Console.WriteLine(string.Join(", ", _inventory));
        }

        public void PlayerHealth()
        {
             // display player health
            Console.WriteLine(Health);
        }
    }
}