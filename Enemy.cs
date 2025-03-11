using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Enemy
    {
        private string name;
        private int health;
        private int min_damage;
        private int max_damage;
        private int min_heal;
        private int max_heal;



        public string Name { get; set; }

        public int Health { get; set; }

        public int MaxHeal
        {
            get { return max_heal; }
            set { max_heal = value; }
        }

        public int MinHeal
        {
            get { return min_heal; }
            set { min_heal = value; }
        }

        public int MaxDamage
        {
            get { return max_damage; }
            set { max_damage = value; }
        }

        public int MinDamage
        {
            get { return min_damage; }
            set { min_damage = value; }
        }
        public int Attack()
        {
            Random r = new Random();
            int damage = r.Next(min_damage, max_damage);
            Console.WriteLine($"The {Name} attacks for {damage} damage!");
            return damage;
        }


        public void TakeDamage(int damage)
        {
            Console.WriteLine($"The {Name} has lost {damage} health!");
        }


        public int Heal()
        {
            Random r = new Random();
            int heal = r.Next(min_heal, max_heal);
            health += heal;
            Console.WriteLine($"The {Name} heals for {heal} health!");
            return health;
        }
    }
}
