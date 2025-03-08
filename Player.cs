using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        private List<string> inventory = new List<string> {};
        private List<string> ItemsForUse = new List<string> {"Sword", "Shield", "Spear"};
        Random random = new Random();
        
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem()
        {
            string chosenItem = ItemsForUse[random.Next(ItemsForUse.Count)];
            Console.WriteLine($" you picked up a {chosenItem}.");
            inventory.Add(chosenItem);
        }
        public void InventoryContents()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("you currently have no items in your inventory.");
            }
            else
            {
                Console.WriteLine("your inventory contains: " + string.Join(", ", inventory));
            }
        }
    }
}