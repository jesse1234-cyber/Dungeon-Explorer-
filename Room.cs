using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        private List<Item> _items;
        private List<Creature> _creatures;
        private bool _hasTreasure;
        private Random _random = new Random();

        public Room(string description, List<Item> items, List<Creature> creatures, bool hasTreasure)
        {
            _description = description;
            _items = items;
            _creatures = creatures;
            _hasTreasure = hasTreasure;
        }

        public string GetDescription()
        {
            return $"Room Description: {_description}";
        }

        public Item GetRandomItem()
        {
            if (_items.Count == 0)
                return null;

            int index = _random.Next(_items.Count);
            Item item = _items[index];
            _items.RemoveAt(index);

            return item;
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public List<Creature> GetCreatures()
        {
            return _creatures;
        }

        public bool HasTreasure()
        {
            return _hasTreasure;
        }
    }
}