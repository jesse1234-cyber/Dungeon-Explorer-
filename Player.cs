using System.Collections.Generic;
using System;
using System.Linq;

namespace Program
{
    public class Player
    {
        public Player() { }
        int Health { get; set; }
        int MaxHealth { get; set; }
        public PlayerInventory pInv = new PlayerInventory(5);


    }

    public class PlayerInventory
    {
        public PlayerInventory(int inCapacity)
        {
            iCapacity = inCapacity;
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

    public abstract class InventoryItem
    {
        public virtual string sName { get; set; }
    }
}