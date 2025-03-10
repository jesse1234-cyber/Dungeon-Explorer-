using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        private List<string> inventory = new List<string>();



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
        public string InventoryContents()
        {
            return null;
        }
        
    }
}

