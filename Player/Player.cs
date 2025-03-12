using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer.Player {
    public class Player {

        public const int MAX_HEALTH = 100;
        public string Name { get; set; }
        public int Health { get; set; }
        private List<Item.Item> inventory = new List<Item.Item>();


        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }


        public void PickUpItem(Item.Item item)
        {
            inventory.Add(item);
        }


        public void UseItem(Item.Item item)
        {
            // Item usage logic
            if (InventoryContents().Contains(item))
            {
                Console.WriteLine($"{Name} uses {item.Name}");
                // Items effects added
                item.Use(this);
            }
            else
            {
                Console.WriteLine($"{Name} does not possess {item.Name}");
            }
        }


        public void TakeDamage(int damage)
        {
            Health -= damage;
        }


        public void AddHealth(int health)
        {
            Health += health;
        }


        public List<Item.Item> InventoryContents()
        {
            return inventory;
        }


        public void RemoveItem(Item.Item item)
        {
            inventory.Remove(item);
            Console.WriteLine($"{item.Name} deleted from inventory.");
        }


        public int getMaxHealth()
        {
            return MAX_HEALTH;
        }

    }
}
