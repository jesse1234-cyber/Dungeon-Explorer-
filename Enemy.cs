using System;


namespace DungeonExplorer
{
    public enum EnemyClass { A, B, C }
    
    public class Enemy
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int Damage { get; }
        
        private static Random rndm = new Random();

        public Enemy(EnemyClass type)
        {
            switch (type)
            {
                case EnemyClass.A:
                    Name = "Demonic Zomboid";
                    Health = rndm.Next(40, 61); // HP 40-60
                    Damage = 15;
                    break;
                case EnemyClass.B:
                    Name = "Sneaky Goblin";
                    Health = rndm.Next(20, 41); // HP 20-40
                    Damage = 10;
                    break;
                case EnemyClass.C:
                    Name = "Deadly Minion";
                    Health = rndm.Next(10, 21); // HP 10-20
                    Damage = 5;
                    break;
            }
            
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
            }
            
        }

        public bool Alive()
        {
            return Health > 0;
        }
    }
}