using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public string NewItem { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            Console.WriteLine($"{item} picked up!");
            NewItem = item;
            inventory.Add(item);
        }
        public void InventoryContents()
        {
            Console.WriteLine($"\nYour inventory currently has:");
            string ShowInventory = string.Join(", ", inventory);
            Console.WriteLine(ShowInventory);
        }
    }
}