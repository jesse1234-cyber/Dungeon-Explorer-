using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; } 
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        //initializes new instance of the player
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(string item)
        {
            Console.WriteLine("Picking up item...");
            inventory.Add(item);
            Console.WriteLine($"{item} added to inventory");
        }

        public string InventoryContents()
        {
            Console.WriteLine("The contents of your inventory are: ");
            return string.Join(", ", inventory);
        }

        public void PlayerInformation()
        {
            Console.WriteLine($"Username: {Name}");
            Console.WriteLine($"Health: {Health}");
        }
    }
}