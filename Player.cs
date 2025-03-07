using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();
        private string v;

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public Player(string v)
        {
            this.v = v;
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            if (inventory.Count == 0)
            {
                return "Your inventory is empty.";
            }
            return string.Join(", ", inventory);
        }
    }
}