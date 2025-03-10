using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a room in the dungeon that can contain items, creatures, and treasure.
    /// </summary>
    public class Room
    {
        private readonly string _description;
        private readonly List<Item> _items;
        private readonly List<Creature> _creatures;
        private readonly bool _hasTreasure;
        private readonly Random _random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="description">The description of the room.</param>
        /// <param name="items">The list of items in the room.</param>
        /// <param name="creatures">The list of creatures in the room.</param>
        /// <param name="hasTreasure">Indicates whether the room has treasure.</param>
        public Room(string description, List<Item> items, List<Creature> creatures, bool hasTreasure)
        {
            _description = description;
            _items = items;
            _creatures = creatures;
            _hasTreasure = hasTreasure;
        }

        /// <summary>
        /// Gets the description of the room.
        /// </summary>
        /// <returns>A string containing the room description.</returns>
        public string GetDescription()
        {
            return $"Room Description: {_description}";
        }

        /// <summary>
        /// Gets a random item from the room and removes it from the list of items.
        /// </summary>
        /// <returns>A random item from the room, or null if no items are present.</returns>
        public Item GetRandomItem()
        {
            if (_items.Count == 0)
                return null;

            int index = _random.Next(_items.Count);
            Item item = _items[index];
            _items.RemoveAt(index);

            return item;
        }

        /// <summary>
        /// Gets the list of items in the room.
        /// </summary>
        /// <returns>A list of items in the room.</returns>
        public List<Item> GetItems()
        {
            return _items;
        }

        /// <summary>
        /// Gets the list of creatures in the room.
        /// </summary>
        /// <returns>A list of creatures in the room.</returns>
        public List<Creature> GetCreatures()
        {
            return _creatures;
        }

        /// <summary>
        /// Determines whether the room has treasure.
        /// </summary>
        /// <returns><c>true</c> if the room has treasure; otherwise, <c>false</c>.</returns>
        public bool HasTreasure()
        {
            return _hasTreasure;
        }
    }
}