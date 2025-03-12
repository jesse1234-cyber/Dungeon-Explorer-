using System;

namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; }
        
        // Only monster or item will be populated, not both
        // Both can also be null
        public MonsterType? Monster { get; }
        public ItemType? Item { get; }

        /// <summary>
        /// Uses random to generate items/monsters that are found in this particular room
        /// </summary>
        /// <param name="player">Player entering the room</param>
        public Room(Player player)
        {
            Random random = new Random();
            Description = Config.RoomDescriptions[random.Next(0, Config.RoomDescriptions.Count)];

            int result = random.Next(1, 11);

            int monsterSpawnThreshold = player.HasBadLuck ? 5 : 7; // Bad luck: 50% chance of monster spawning, otherwise 30% chance
            int itemSpawnThreshold = player.HasBadLuck ? 3 : 4; // Bad luck: 20% chance of item spawning, otherwise 30% chance
            
            if (result >= monsterSpawnThreshold)
                Monster = (MonsterType) random.Next(0, Enum.GetValues(typeof(MonsterType)).Length);
            else if (result >= itemSpawnThreshold)
            {
                random = new Random();
                result = random.Next(1, 11);
                
                // 1/10 chance of getting escape code
                if (result == 10)
                {
                    Item = ItemType.EscapeCode;
                    return;
                }
                
                result = random.Next(0, 2);
                if (result == 0)
                    Item = ItemType.Shield;
                else
                    Item = ItemType.HealthPotion;
            }
        }
    }
}