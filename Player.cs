using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        private int health;
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            this.health = health;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int val)
        // Used when player's health changes. 
        { // Check if health is above 100 to avoid negative HP.
            if (val < 0)
            {
                health = 0; 
            }
            else
            { // Update Health with the given value. 
                health = val;
            }
            
        }
        public void PickUpItem(string item)
        {
            if (inventory.Count == 0)
            {
                inventory.Add(item);
                Console.WriteLine($"You found and picked up {item}");
            }
            else
            {
                Console.WriteLine("You can only have one item at a time.");
            }
        }
        public string InventoryContents()
        {
            // If there are no items in the list, return the message,
            // Otherwise output the content. 
            return inventory.Count > 0 ? string.Join(", ", inventory) : "no items found.";
        }
    }
}