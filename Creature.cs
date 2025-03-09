using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Attack { get; private set; }
        public int Level { get; private set; }
        public bool IsAlive { get; private set; }

        public Creature(string name, int health, int attack, int level) 
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health;
            Attack = attack;
            Level = level;
            IsAlive = true;

        }
        // Protected methods allow subclasses to modify stats for potion use.
        protected void SetAttack(int attack)
        {
            Attack = attack;
        }
        protected void SetMaxHealth(int health)
        {
            MaxHealth = health;
        }
        protected void SetCurrentHealth(int health)
        {
            CurrentHealth = health;
        }
        public virtual void AttackTarget(Creature target)
        {
            if (target.CurrentHealth - Attack > 0)
            {
                target.CurrentHealth -= Attack;
            }
            else
            {
                target.CurrentHealth = 0;
                target.IsAlive = false;
            }

        }
        public abstract void UsePotion(Potion potion);
    }

    public class Player : Creature
    {
        public Weapon EquippedWeapon { get; private set; }
        public Inventory PlayerInventory = new Inventory();
        public Player(string name, int health, int attack, int level) : base(name, health, attack, level)
        {
            EquippedWeapon = null;
        }
        public override void UsePotion(Potion potion)
        {
            PlayerInventory.RemovePotion(potion);
            SetMaxHealth(MaxHealth + potion.HealthBonus);
            if (CurrentHealth + potion.HealthRestore > MaxHealth)
            {
                SetCurrentHealth(MaxHealth);
            }
            else
            {
                SetCurrentHealth(CurrentHealth + potion.HealthRestore);
            }
            SetAttack(Attack + potion.HealthBonus);
        }
        public void EquipWeapon(Weapon weapon)
        {
            if (EquippedWeapon == null)
            {
                EquippedWeapon = weapon;
                PlayerInventory.RemoveWeapon(weapon);
                SetAttack(Attack + weapon.Damage);
            }
            else
            {
                PlayerInventory.AddWeapon(EquippedWeapon);
                SetAttack(Attack - EquippedWeapon.Damage);
                EquippedWeapon = weapon;
                SetAttack(Attack + weapon.Damage);
            }
        }
        public void UnequipWeapon()
        {
            if (EquippedWeapon != null)
            {
                PlayerInventory.AddWeapon(EquippedWeapon);
                SetAttack(Attack - EquippedWeapon.Damage);
                EquippedWeapon = null;
            }
        }
    }
    public class Monster : Creature
    {
        public Monster(string name, int health, int attack, int level) : base(name, health, attack, level)
        {
        }
        public override void UsePotion(Potion potion)
        {
            SetMaxHealth(MaxHealth + potion.HealthBonus);
            if (CurrentHealth + potion.HealthRestore > MaxHealth)
            {
                SetCurrentHealth(MaxHealth);
            }
            else
            {
                SetCurrentHealth(CurrentHealth + potion.HealthRestore);
            }
            SetAttack(Attack + potion.HealthBonus);
        }
    }

}