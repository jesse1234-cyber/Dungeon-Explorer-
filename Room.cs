using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a Room that the Player can explore.
    /// </summary>
    public class Room
    {
        private readonly string description = "";
        private List<string> items = new List<string>();
        private readonly string name = "";

        /// <summary>
        /// Constructs a Room object.
        /// </summary>
        /// <param name="name">The name of the Room.</param>
        /// <param name="description">The description of the Room.</param>
        /// <param name="items">The items that are inside of the Room.</param>
        public Room(string name, string description, List<string> items)
        {
            if (name != null)
            {
                this.name = name;
            }
            if (description != null)
            {
                this.description = description;
            }
            this.SetItems(items);
        }

        /// <summary>Returns the Room's name.</summary>
        /// <returns>The name string.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>Returns the Room's description.</summary>
        /// <returns>The description string.</returns>
        public string GetDescription()
        {
            return this.description;
        }

        private void SetItems(List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                items.ForEach(item =>
                {
                    this.AddItem(item);
                });
            }
            else
            {
                this.items = new List<string>();
            }
        }

        private void AddItem(string item)
        {
            this.items.Add(item);
        }
    }
}