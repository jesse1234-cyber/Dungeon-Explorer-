using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Schema;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; set; }
        public Player (string name)
        {
            Name = name;
        }
        public int Health { get; set; }
        public const int maxhealth = 100;
       
        private List<string> inventory = new List<string>();

        public void displayhealth ()
        {
            Console.WriteLine ("current health is" +Health);
        }

        public void takeDamage(int dmg)
        {
            Health = Health - dmg;
         
        }
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
            
             
            
        }
        
        public void PickUpItem(string item)
        {
           inventory.Add(item);

            Console.WriteLine($"{Name} picked up {item}");
        }
        public void showinventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("your inventory is empty");
            }
            else
            {
                Console.WriteLine("currently in your inventory is:");
                foreach (string item in inventory)
                {
                    Console.WriteLine($"-{item}");
                }
            }
        }

        
        public string InventoryContents()
        {
            return null;
        }
        
    }
}

