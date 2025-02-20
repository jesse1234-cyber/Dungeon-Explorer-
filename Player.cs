using System.Collections.Generic;
using System;
using System.Linq;

namespace Program
{
    public class Player
    {
        public Player() {
            pInv = new PlayerInventory(5);
        }
        int Health { get; set; }
        int MaxHealth { get; set; }
        public PlayerInventory pInv;


    }

    public class PlayerInventory
    {
        public PlayerInventory(int inCapacity)
        {
            iCapacity = inCapacity;
            for (int i = 0; i < iCapacity; i++)
            {
                Inventory.Add(new InventoryItem("Sausage Roll", 3, 10));
            }
        }

        private int iCapacity { get; set; }
        private List<InventoryItem> Inventory = new List<InventoryItem>();

        public string fPickUpItem(InventoryItem ItemToAdd)
        {
            if (Inventory.Count == iCapacity)
            {
                return "Your inventory is full! You must drop something first";
            }
            Inventory.Add(ItemToAdd);
            return "Item Added";
        }
        public string fShowInventory()
        {
            for (int i = 0; i < iCapacity; i++)
            {
                Console.WriteLine("[" + (i + 1).ToString() + "] " + Inventory[i].sName + ": " + Inventory[i].noOfItem.ToString() + "/" + Inventory[i].maxNoOfItem.ToString());
            }

            return null;
        }
        private string fDeleteItem(InventoryItem ItemToRemove, InventoryItem ItemToAdd)
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
            this.noOfItem = 0;
        }
        public InventoryItem(string name, int maxNoOfItem, int noOfItem)
        {
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = noOfItem;
        }
    }
}