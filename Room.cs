using System;

namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; }
        
        // Only monster or item will be populated, not both
        public MonsterType Monster { get; }
        public ItemType Item { get; }

        // Player is the player entering the Room
        public Room(Player player)
        {
            // Assign random description
            // Random item/monster depending on player luck
        }
    }
}