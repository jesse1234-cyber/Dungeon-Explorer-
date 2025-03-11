using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Initialises the name and health attribute for the player. 
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        // The string below adds the item the user found to their inventory. 
        public void FindItems(string item)
        {
        inventory.Add(item);
        }
        // The string below returns all the items in the player's backpack (inventory). 
        public string Backpack()
        {
            return string.Join(", ", inventory);
        }
        // The code below returns the user's health value. 
        public int ShowHealth()
        {
            return this.Health;
        }
        // The code below boosts the player's health when they choose to eat. 
        public string Eat()
        {
            Console.WriteLine("You ate some bread you found on the floor and have healed 40 health.");
            this.Health = this.Health + 40;
            return $"Your health is: {this.Health}";
        }
        // The boolean (true or false data type) value below will return true if the user has something in their inventory and false if they don't. 
        // This can be called in the main program to determine whether the user has searched for items or not. 
        public bool FindItems()
        {
            if (inventory.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}