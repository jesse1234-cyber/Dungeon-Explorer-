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
            for (int i = 0; i < iCapacity - 1; i++) { 
                Inventory.Add(new InventoryItem("Sausage Roll"));
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
            for (int i = 0; i < iCapacity - 1; i++)
            {
                Console.WriteLine("[", iCapacity.ToString(), "] ", Inventory[i].sName);
            }

            return null;
        }
        private string fDeleteItem(int iItemToRemove, InventoryItem ItemToAdd)
        {

            return null;
        }

    }

    public class InventoryItem
    {
        public virtual string sName { get; set; }
        public InventoryItem(string name)
        {
            sName = name;
        }
    }
}