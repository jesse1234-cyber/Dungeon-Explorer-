using System;

namespace DungeonExplorer
{
    public static class Monster
    {
        public static void AttackPlayer(Player player, MonsterType monsterType)
        {
            switch (monsterType)
            {
                case MonsterType.Witch:
                    player.GiveBadLuck();
                    break;
                case MonsterType.Thief:
                    player.StealItem();
                    player.RemoveHealth(5);
                    break;
                case MonsterType.Zombie:
                    player.RemoveHealth(15);
                    break;
            }
        }
    }
}