using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class forms the base of the Potion and Weapon classes.
    public abstract class Item
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        protected string description;
        public Item(string name, int damage)
        {
            Name = name;
            Damage = damage;
            description = "";
        }
        // Abstract method, as item values are unique to each subclass.
        public abstract void CreateDescription();
        public string GetDescription()
        {
            CreateDescription();
            return description;
        }
    }
    public class Potion : Item
    {
        // HealthRestore is the amount of health restored by the potion (cannot exceed max health).
        public int HealthRestore { get; private set; }
        // HealthBonus is the amount of health added to the player's max health.
        public int HealthBonus { get; private set; }
        // Damage is inherited from the Item class. It is the amount of damage the potion adds to the player's attack.
        public Potion(string name, int damage, int healthRestore, int healthBonus) : base(name, damage)
        {
            HealthRestore = healthRestore;
            HealthBonus = healthBonus;
        }
        // Potion specific override of CreateDescription.
        public override void CreateDescription()
        {
            Console.WriteLine($"{HealthRestore}, {HealthBonus}, {Damage}");
            description = $"Name: {Name}";
            // Only adds attributes if their value > 0.
            if (HealthRestore > 0)
            {
                description += $"\nHealth Restore: {HealthRestore}";
            }
            if (HealthBonus > 0)
            {
                description += $"\nHealth Bonus: {HealthBonus}";
            }
            if (Damage > 0)
            {
                description += $"\nAttack Bonus: {Damage}";
            }
        }
    }
    public class Weapon : Item
    {
        public Weapon(string name, int damage) : base(name, damage)
        {
        }
        // Weapon specific override of CreateDescription.
        public override void CreateDescription()
        {
            description = $"Name: {Name}\nDamage: {Damage}";
        }
    }
}
