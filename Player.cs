using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();
        public Room CurrentRoom;

        public Player(int health)
        {
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
        


 
        public void PickUpItem(string item)
        {
            
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}