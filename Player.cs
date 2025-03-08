using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public string NewItem { get; private set; }
        public string ShowInventory { get; private set; }
        private List<string> inventory = new List<string>();


        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }


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


        public void PickUpItem(string item)
        {
            Console.WriteLine($"{item} picked up!");
            NewItem = item;
            inventory.Add(item);
        }


        public string InventoryContents()
        {
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