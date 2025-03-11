using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        private int health;
        internal Item inventoryItem;
        public bool FirstRoom { get; private set; } = true;
        public bool PickedUpItem { get; set; } = false;

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
        public void PickUpItem(Item newItem)
        {
            if (inventoryItem == null)
            {
                inventoryItem = newItem;
                Console.WriteLine($"You found and picked up {inventoryItem.Name}");
            }
            else
            {
                Console.WriteLine($"You already have {inventoryItem.Name}.");
            }
        }

        public void UseItem()
        {
            if (inventoryItem == null)
            {
                Console.WriteLine("You don't have items to use.");
                return;
            }
            
            inventoryItem.UseItem(this);
            inventoryItem = null;
        }
        public string InventoryContents()
        {
            // If there are no items in the list, return the message,
            // Otherwise output the content. 
            return inventoryItem != null ? inventoryItem.ToString() : "no items found.";
        }

        public void NextRoom()
        {
            FirstRoom = false;
        }
    }
}