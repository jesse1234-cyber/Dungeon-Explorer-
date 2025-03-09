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

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            health = 100;
        }

        static void Damage(int damage, int health)
        {
            health = health - damage;
            damage = 20;

        }

        static void ShowHealth(int health);
        


 
        public void PickUpItem(string item)
        {
            
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}