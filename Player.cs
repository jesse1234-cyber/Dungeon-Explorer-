using System.Collections.Generic;

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
        public void PickUpItem(string item)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
            }
        }
        public string InventoryContents()
        {
            return inventory.Count == 0 ? "Empty" : string.Join(", ", inventory);
        }
    }
}