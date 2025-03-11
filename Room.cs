using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        // Public name for display
        public string Name { get; private set; }
        
        // Room details
        private readonly string description;
        private readonly List<Item> items;
        private readonly List<Monster> monsters;
        
        // Exits mapped by direction
        private readonly Dictionary<string, string> exits;

        public Room(string name, string description)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Room needs a name!", nameof(name));
            
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Room needs a description!", nameof(description));
            
            // Initialize room
            Name = name;
            this.description = description;
            items = new List<Item>();
            monsters = new List<Monster>();
            exits = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public string GetDescription()
        {
            return $"{Name}\n{description}";
        }
        
        #region Item Management
        
        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Can't add null item!");
            
            items.Add(item);
        }
        
        public bool RemoveItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Can't remove null item!");
            
            return items.Remove(item);
        }
        
        public Item GetItem(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
                return null;
            
            // Find item by name (case-insensitive)
            return items.FirstOrDefault(i => 
                i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
        
        public IReadOnlyList<Item> GetItems()
        {
            return items.AsReadOnly();
        }
        
        public bool HasItems()
        {
            return items.Count > 0;
        }
        
        #endregion
        
        #region Monster Management
        
        public void AddMonster(Monster monster)
        {
            if (monster == null)
                throw new ArgumentNullException(nameof(monster), "Can't add null monster!");
            
            monsters.Add(monster);
        }
        
        public bool RemoveMonster(Monster monster)
        {
            if (monster == null)
                throw new ArgumentNullException(nameof(monster), "Can't remove null monster!");
            
            return monsters.Remove(monster);
        }
        
        public Monster GetMonster(string monsterName)
        {
            if (string.IsNullOrWhiteSpace(monsterName))
                return null;
            
            // Find monster by name (case-insensitive)
            return monsters.FirstOrDefault(m => 
                m.Name.Equals(monsterName, StringComparison.OrdinalIgnoreCase));
        }
        
        public IReadOnlyList<Monster> GetMonsters()
        {
            return monsters.AsReadOnly();
        }
        
        public bool HasMonsters()
        {
            return monsters.Count > 0;
        }
        
        #endregion
        
        #region Exit Management
        
        public void AddExit(string direction, string destinationRoom)
        {
            // Validate parameters
            if (string.IsNullOrWhiteSpace(direction))
                throw new ArgumentException("Direction can't be empty", nameof(direction));
            
            if (string.IsNullOrWhiteSpace(destinationRoom))
                throw new ArgumentException("Destination room can't be empty", nameof(destinationRoom));
            
            // Add exit (overwrites if already exists)
            exits[direction.ToLower()] = destinationRoom;
        }
        
        public string GetExitRoom(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
                return null;
            
            // Dictionary already uses OrdinalIgnoreCase comparer
            return exits.TryGetValue(direction, out string destination) ? destination : null;
        }
        
        public IReadOnlyDictionary<string, string> GetExits()
        {
            return exits;
        }
        
        #endregion
        
        // Utility methods for later expansion
        
        public bool HasExit(string direction)
        {
            return !string.IsNullOrWhiteSpace(direction) && exits.ContainsKey(direction);
        }
        
        public int ExitCount => exits.Count;
    }
}
