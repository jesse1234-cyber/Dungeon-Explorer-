using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

// Need to learn about get/set methods

namespace DungeonExplorer
{
    public class Player // Need to know how to create an object/intertwine it with the other modules. Ask AI tomorrow if after tutorial you are stuck.
    {
        public string Name { get; private set; } // Property
        public int Health { get; private set; } // Property
        
        // List is private (encapsulation), can only be accessed within the Player class
        private List<string> inventory = new List<string>(); // intialising list of items the player picks up

        public Player(string name, int health) //Constructor w/ fields
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item) // Recieves item. Function for putting it into the inventory
        {
            inventory.Add(item);
            Console.WriteLine($"{item} was added to your inventory!");
        }
        public string InventoryContents() // Allows player to see inventory
        {
            return string.Join(", ", inventory);
        }
    }
}