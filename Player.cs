using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Item
    {
        public string name;
        public string desc;
        public Item(string _name, string _desc)
        {
            name = _name;
            desc = _desc;
        }
    }
    public class Player
    {
        public int LevelNumber = 1;
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventory = new List<Item>();
        public Room CurrentRoom;

        public Player(int health)
        {
            inventory = new List<Item>();
            Health = health;
            Console.WriteLine("What would you like your username to be?");
            String Name = Console.ReadLine();
            Console.WriteLine("Your username is: " + Name);
                      
        }
        public void Damage(int damage)
        {
            Health = Health - damage;
        }
        public void ShowHealth() 
        {
            Console.WriteLine("Health is currently:" + Health);
        } 
        public void PickUpItem(Item item)
        {
            inventory.Add(item);
            InventoryContents();
        }
        public void InventoryContents()
        {
            Console.Write("Your current inventory is: ");

            foreach (Item i in inventory)
            {
                Console.Write("" + i.name +" ");
            }
            Console.Read();
        }
    }
}