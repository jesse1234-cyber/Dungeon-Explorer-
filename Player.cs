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
        public void PickUpItem(string collectable)
        {
            this.inventory.Add(collectable);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public string GetStatus()
        {
            string HealthString = Health.ToString();
            return $"{HealthString} {InventoryContents()}";
            
        }
    }
}