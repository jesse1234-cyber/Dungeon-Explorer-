using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player // Need to know how to create an object/intertwine it with the other modules.
    {
        public string Name { get; private set; } // Property
        public int Health { get; private set; } // Property
        
        // List is private (encapsulation), can only be accessed within the Player class
        
        /// <summary>
        /// Initialising iventory as a List for the player
        /// to be able to view with a later function; "StatusCheck()" in Game.cs
        /// </summary>
        private List<string> inventory = new List<string>(); // Encapsulation; preventing accidental modifications in the. Only avaliable to the Player class. intialising list of items the player picks up

        /// <summary>
        /// Allows for the an instance for a player to be initialised, alongside the class NewPlayer
        /// (which has the function of allowing for a name input)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>u
        public Player(string name, int health) //Constructor w/ fields
        {
            Name = name;
            Health = health;
        }
        /// <summary>
        /// "item" picked from availableItems from the "ItemSelector()"
        /// function gets added to player's inventory to check (and potentially use)
        /// </summary>
        /// <param name="item"></param>
        public void PickUpItem(string item) // Recieves item. Function for putting it into the inventory
        {
            inventory.Add(item);
            Console.WriteLine($"{item} was added to your inventory!");
        }
        /// <summary>
        /// Selection if as error handling in case nothing 
        /// is currently in the player's inventory
        /// </summary>
        /// <returns>list of "item"s in the inventory</returns>
        public string InventoryContents() // Allows player to see inventory
        {
            if (inventory.Count == 0) 
            {
                return "Your inventory is empty!";
            }
            else
            {
                return string.Join(", ", inventory);
            }
        }
    }
}