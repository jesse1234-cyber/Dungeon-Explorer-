using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;

namespace DungeonExplorer
{
    public class Player
    {
        // Public properties with private setters.
        public string Name { get; private set; }
        public int Health { get; private set; }
        public string NewItem { get; private set; }
        public string ShowInventory { get; private set; }
        // Fully private property.
        private List<string> inventory = new List<string>();

        /// Constructor initialises the players name.
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        
        /// Method to get the users name.
        public string GetName()
        {
            Console.WriteLine("Please enter a username: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Blank";
            }
            return name;
        }


        /// Method to pick up the item in the current room.
        public void PickUpItem(string item)
        {
            Console.WriteLine($"{item} picked up!");
            NewItem = item;
            inventory.Add(item);
        }


        /// Method to Show the contents of the inventory.
        public string InventoryContents()
        {
            // Checks if the inventory is empty or not
            if ( inventory.Count == 0)
            {
                ShowInventory = ("Nothing :(");
            }
            else
            {
                ShowInventory = string.Join(", ", inventory);
            }
            return ShowInventory;
        }
    }
}