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
        public const int maxhealth = 100; //sets max player health to be 100
       
        private List<string> inventory = new List<string>();

        public void displayhealth ()
        {
            Console.WriteLine ("current health is" +Health); //shows the players current health when they want to ask for it
        }

        public void takeDamage(int dmg)
        {
            Health = Health - dmg;                  // calculates damage and the health remaining after damage has been taken
         
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
                Console.WriteLine("your inventory is empty");  //shows that the players inventory is empty 
            }
            else
            {
                Console.WriteLine("currently in your inventory is:");   // shows the players current inventory 
                foreach (string item in inventory)
                {
                    Console.WriteLine($"-{item}");     //displays the current item in the players inventory
                }
            }
        }

        
        public string InventoryContents()
        {
            return null;
        }
        
    }
}

