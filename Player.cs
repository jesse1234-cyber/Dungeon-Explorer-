using System.Collections.Generic;
using System.Security.Cryptography;

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
        }

        public Player(string v)
        {
        }

        public void PickUpItem(string item)
        {
            // Add the item to the player's inventory
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}