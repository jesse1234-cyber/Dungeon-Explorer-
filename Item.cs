using System;

namespace DungeonExplorer
{
    public class Item
    {
        public string Name { get; private set; }
        public int Armor { get; private set; }
        public int Healing { get; private set; }
        public int Damage { get; private set; }

        public Item(string name, int armor = 0, int healing = 0, int damage = 0)
        {
            Name = name;
            Armor = armor;
            Healing = healing;
            Damage = damage;
        }
    }
}