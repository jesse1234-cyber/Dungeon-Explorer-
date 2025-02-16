using System.Collections.Generic;

namespace DungeonExplorer
{

    // Player class that inherits from Entity
    public class Player : Entity
    {
      
        private List<Item> inventory = new List<Item>();

        public Player(string name, int health) 
        {
            // Set the player's name and health
            Name = name;
            Health = health;
        }
        public void PickUpItem(Item item)
        {
            // Add the item to the player's inventory
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            // Return the contents of the player's inventory
            return string.Join(", ", inventory);
        }
    }
}