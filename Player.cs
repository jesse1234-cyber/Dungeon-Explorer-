using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Player name cannot be empty.");
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Player health cannot be set to zero or be negative.");
                }
                else
                {
                    health = value;
                }
            }
        }
        private List<string> inventory = new List<string>();

        public void PickUpItem(string item)
        {
            if (inventory.Contains(item))
            {
                Console.WriteLine(item + " already in inventory!");
            }
            else
            {
                Console.WriteLine("Picked up: " + item);
                inventory.Add(item);
            }


        }

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}

