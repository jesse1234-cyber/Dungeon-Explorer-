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
                    player.GetAttacked(10);
                    break;
                case MonsterType.Zombie:
                    player.GetAttacked(20);
                    break;
            }
        }
    }
}