using System;

namespace DungeonExplorer
{
    public class Creature
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        
        public int Damage { get; private set; }

        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}