using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        private Dictionary<string, int> _items;
        private Random _random = new Random();

        public Room(string description, List<string> items)
        {
            this._description = description;
            this._items = new Dictionary<string, int>();
            foreach (var item in items)
            {
                if (_items.ContainsKey(item))
                {
                    _items[item]++;
                }
                else
                {
                    _items[item] = 1;
                }
            }
        }

        public string GetDescription()
        {
            return $"Room Description: {_description}";
        }

        public string GetRandomItem()
        {
            if (_items.Count == 0)
                return null;

            var itemList = new List<string>(_items.Keys);
            int index = _random.Next(itemList.Count);
            string item = itemList[index];

            if (_items[item] > 1)
            {
                _items[item]--;
            }
            else
            {
                _items.Remove(item);
            }

            return item;
        }
    }
}