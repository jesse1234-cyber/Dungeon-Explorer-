using System.Collections.Generic;

namespace DungeonExplorer
{

    // Player class that inherits from Entity
    public class Player : Entity
    {
      
        private List<Item> inventory = new List<Item>();

        // Player Constructor
        // Arguments:
        // name - the name of the player
        // health - the health of the player
        public Player(string name, int health) 
        {
            // Set the player's name and health / maxHealth
            Name = name;
            Health = health;
            maxHealth = health;
        }
        // Inventory Setter
        public void PickUpItem(Item item)
        {
            // Add the item to the player's inventory
            inventory.Add(item);
        }
        // Inventory Getter
        public string InventoryContents()
        {
            // Return the contents of the player's inventory
            return string.Join(", ", inventory);
        }
    }
}