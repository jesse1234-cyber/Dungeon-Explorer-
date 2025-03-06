using System.Collections.Generic;
using System;
using System.Linq;

namespace Program
{

    // Class for the player, with health attributes and an instance of the inventory object
    public class Player
    {
        public Player() {
            pInv = new PlayerInventory(5);
        }
        int Health { get; set; }
        int MaxHealth { get; set; }
        public PlayerInventory pInv;


    }


    // Player inventory class, with various functions to manage the inventory
    public class PlayerInventory
    {
        public PlayerInventory(int inCapacity)
        {
            iCapacity = inCapacity;
           
             Inventory.Add(new InventoryItem("Sausage Roll", 10, 3)); // Initializes the list of inventory items
            
        }
        private int iCapacity { get; set; }
        private List<InventoryItem> Inventory = new List<InventoryItem>();

        public string fPickUpItem(InventoryItem ItemToAdd) // Adds an item to players inventory (Checking its not full first)
        {
            if (Inventory.Count == iCapacity)
            {
                return "Your inventory is full! You must drop something first";
            }
            Inventory.Add(ItemToAdd);
            return "Item Added";
        }
        public string fShowInventory() // Shows the player the current items in there inventory
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine("[" + (i + 1).ToString() + "] " + Inventory[i].sName + ": " + Inventory[i].noOfItem.ToString() + "/" + Inventory[i].maxNoOfItem.ToString());
            }

            return null;
        }
        private string fDeleteItem(InventoryItem ItemToRemove, InventoryItem ItemToAdd) // Remove item from the inventory
        {
            Inventory.Remove(ItemToRemove);
            return null;
        }

    }

    public class InventoryItem
    {
        public int maxNoOfItem { get; set; }
        public int noOfItem { get; set; }
        public string sName { get; set; }
        public InventoryItem(string name, int maxNoOfItem)
        {
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = 1;
        }
        public InventoryItem(string name, int maxNoOfItem, int noOfItem)
        {
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = noOfItem;
        }
    }
}