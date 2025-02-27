using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public static string Name { get; private set; }
        public static int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
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