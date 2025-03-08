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
                    Health = rndm.Next(50, 71); // HP 50-70
                    Damage = 20;
                    break;
                case EnemyClass.B:
                    Name = "Sneaky Goblin";
                    Health = rndm.Next(30, 51); // HP 30-50
                    Damage = 15;
                    break;
                case EnemyClass.C:
                    Name = "Deadly Minion";
                    Health = rndm.Next(10, 31);
                    Damage = 10;
                    break;
            }
            
        }
        
        public void TakeDamage(int damage)
    }
}