using System;
using System.Collections.Generic;
using System.Configuration;

namespace DungeonExplorer
{
    /// <summary>
    /// the main coding logic  player, allowing important features to be defined
    /// </summary>
    public class Player
    {
        /// <summary>
        /// the name can be accessed by other files but cannot be changed in other files,
        /// the health can be accessed and changed by other files, allowing health to increase or decrease
        /// in the main game code
        /// </summary>
        public string Name { get; private set; } 
        public int Health { get; set; }
        /// <summary>
        /// the inventory is a list of strings
        /// </summary>
        private List<string> inventory = new List<string>();

        /// <summary>
        /// an instance of the player is initialized
        /// </summary>
        /// <param name="name">
        /// the name of the player
        /// </param>
        /// <param name="health">
        /// the health which the player is assigned
        /// </param>
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// an item is picked up and saved to the inventory list, a message is
        /// also displayed showing what item was added to the inventory
        /// </summary>
        /// <param name="item">
        /// the name of them item which the user has picked up
        /// </param>
        public void PickUpItem(string item)
        {
            Console.WriteLine("Picking up item...");
            inventory.Add(item);
            Console.WriteLine($"{item} added to inventory");
        }

        /// <summary>
        /// this method displays the items in the inventory, seperated by a comma
        /// </summary>
        /// <returns>
        /// the inventory list, each element of the list is seperated by a comma
        /// </returns>
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}