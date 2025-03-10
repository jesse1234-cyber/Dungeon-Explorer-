using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;  // Multiple items in the room
        public string Name { get; private set; }  // Name of the room for easy identification

        /// <summary>
        /// Constructor that takes a name, description, and a list of items.
        /// </summary>
        public Room(string name, string description, List<string> items = null)
        {
            Name = name;
            this.description = description;
            this.items = items ?? new List<string>();
        }

        /// <summary>
        /// Gets the description of the room.
        /// </summary>
        public string GetDescription()
        {
            return $"{Name}: {description}";
        }

        /// <summary>
        /// Gets the list of items in the room.
        /// </summary>
        public List<string> GetItems()
        {
            return items;
        }

        /// <summary>
        /// Checks if the room has any items.
        /// </summary>
        public bool HasItems()
        {
            return items.Count > 0;
        }

        /// <summary>
        /// Allows the player to pick up an item.
        /// </summary>
        public bool PickUpItem(string item, Player player)
        {
            if (items.Contains(item))
            {
                player.PickUpItem(item);
                items.Remove(item);  // Remove the item from the room after it's picked up
                return true;
            }
            return false;  // Item not found
        }
    }
}
