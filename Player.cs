using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing the Player in the text-based adventure, using a user-set name.
    /// </summary>
    public class Player
    {
        private readonly string name;
        private readonly int health;
        private readonly List<string> inventory = new List<string>();

        /// <summary>
        /// Constructs a Player object.
        /// </summary>
        /// <param name="name">The name of the Player.</param>
        /// <param name="health">The amount of health points the Player has.</param>
        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        /// <summary>Returns the Player's name.</summary>
        /// <returns>The name string.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>Returns the Player's health value.</summary>
        /// <returns>The health integer.</returns>
        public int GetHealth()
        {
            return this.health;
        }

        /// <summary>Returns the contents of the inventory list. If the inventory is empty,
        /// an empty string is returned. </summary>
        /// <returns>A string of all the elements inside of inventory, seperated by commas.</returns>
        public string GetInventoryContents()
        {
            return string.Join(", ", this.inventory);
        }

        /// <summary>Adds the parameter-specified item to the inventory list.</summary>
        /// <param name="item"> The specified item to be added to the Player's inventory.</param>
        public void PickUpItem(string item)
        {
            this.inventory.Add(item);
        }

        /// <summary>
        /// Checks if the user's inventory list contains the specified key and returns a
        /// Boolean value representing this.</summary>
        /// <returns>A Boolean value representing whether the inventory list contains the
        /// "Bone Key" item.</returns>
        public bool TryOpenDoor()
        {
            return (this.inventory.Contains("Bone Key"));
        }

        /// <summary>
        /// Checks if the inventory list is empty and, corresponding to the truth of the
        /// statement, returns a Boolean value.</summary>
        /// <returns>A Boolean value representing whether the list contains any elements.</returns>
        public bool IsInvEmpty()
        {
            return !this.inventory.Any();
        }
    }
}