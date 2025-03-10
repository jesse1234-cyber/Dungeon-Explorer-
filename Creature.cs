using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // This class forms the base of the Player and Monster classes.
    public abstract class Creature
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Attack { get; private set; }
        public int Level { get; private set; }
        public bool IsAlive { get; private set; }
        // Constructor for the Creature class.
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
        // AttackTarget method uses a d20 roll to determine damage dealt.
        public virtual void AttackTarget(Creature target)
        {
            Random dice = new Random();
            int damage = (Attack * dice.Next(1,21)) / 20; //Attack value acts as a 'modifier' for the d20 roll.
            Console.WriteLine($"The attack deals {damage} damage.");
            if (target.CurrentHealth - damage > 0)
            {
                target.CurrentHealth -= damage;
            }
            else
            {
                target.CurrentHealth = 0;
                target.IsAlive = false;
            }

        }
        // Abstract method for potion use, as monsters do not have an inventory.
        public abstract void UsePotion(Potion potion);
    }
    // Player class
    public class Player : Creature
    {
        public Weapon EquippedWeapon { get; private set; }
        public Inventory PlayerInventory = new Inventory();
        // Constructor for the Player class.
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
        // Menu method allows the player to check stats and use inventory.
        public void Menu()
        {
            while (true)
            {
                // Displays stats.
                Console.WriteLine("\nStats:");
                Console.WriteLine($"Health: {CurrentHealth}");
                Console.WriteLine($"Attack: {Attack}");
                Console.WriteLine($"Level: {Level}");
                if (EquippedWeapon == null)
                {
                    Console.WriteLine("Equipped Weapon: None");
                }
                else
                {
                    Console.WriteLine($"Equipped Weapon: {EquippedWeapon.Name}");
                }
                // Displays inventory with PlayerInventory.Contents().
                Console.Write("\nInventory:");
                Console.WriteLine(PlayerInventory.Contents());
                // Displays and determines what actions the user can take.
                string actions = "Actions:";
                if (PlayerInventory.WeaponCount() > 0)
                {
                    actions += "\nW) Equip Weapon";
                }
                if (EquippedWeapon != null)
                {
                    actions += "\nU) Unequip Weapon";
                }
                if (PlayerInventory.PotionCount() > 0)
                {
                    actions += "\nP) Drink Potion";
                }
                actions += "\nQ) Quit Menu";
                Console.WriteLine(actions);
                Console.Write(">");
                // Takes and validates user input, breaks from while true loop when a valid input is given.
                string userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "W" && PlayerInventory.WeaponCount() > 0)
                {
                    // While loop until user enters a valid input.
                    while (true)
                    { 
                        Console.Write("Select the weapon you want to equip, or enter Q to exit: ");
                        userChoice = Console.ReadLine().ToUpper();
                        if (userChoice == "Q")
                        {
                            break;
                        }
                        else
                        {
                            // Try catch to handle invalid inputs.
                            try
                            {
                                int weaponChoice = Convert.ToInt32(userChoice) - 1;
                                if (0 <= weaponChoice && weaponChoice <= PlayerInventory.WeaponCount())
                                {
                                    EquipWeapon(PlayerInventory.GetWeapon(weaponChoice));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Your input was out of range.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter a valid input.");
                            }
                        }
                    }
                }
                else if (userChoice == "U" && EquippedWeapon != null)
                {
                    UnequipWeapon();
                }
                else if (userChoice == "P" && PlayerInventory.PotionCount() > 0)
                {
                    while (true)
                    {
                        Console.Write("Select the potion you want to drink, or enter Q to exit: ");
                        userChoice = Console.ReadLine().ToUpper();
                        if (userChoice == "Q")
                        {
                            break;
                        }
                        else
                        {
                            try
                            {
                                int potionChoice = Convert.ToInt32(userChoice) - 1;
                                if (0 <= potionChoice && potionChoice <= PlayerInventory.PotionCount())
                                {
                                    UsePotion(PlayerInventory.GetPotion(potionChoice));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Your input was out of range.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter a valid input.");
                            }
                        }
                    }
                }
                else if (userChoice == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }
        public void EquipWeapon(Weapon weapon)
        {
            // If the player has a weapon equipped, this code makes sure that it is not overriden when a new weapon is equipped.
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
                PlayerInventory.RemoveWeapon(weapon);
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
    // Monster subclass
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