using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public Monster Monster { get; private set; }
        public List<Potion> Potions { get; private set; }
        public Weapon Weapon { get; private set; }
        private string Description; // Accessed through methods detailed below.
        public Room(Monster monster, List<Potion> potions, Weapon weapon)
        {
            Monster = monster;
            Potions = potions;
            Weapon = weapon;
            Description = "";
        }
        // Generates a description of the room.
        public void CreateDescription()
        {
            string description = "Room Contents:";
            description += "\nMonster: ";
            if (Monster == null)
            {
                description += "There is no monster in the room.";
            }
            else
            {
                description += Monster.Name;
            }
            description += "\nPotions: ";
            if (Potions == null)
            {
                description += "There is no potion in the room.";
            }
            else
            {
                for (int i = 0; i < Potions.Count; i++)
                {
                    description += Potions[i].Name;
                    if (i < Potions.Count - 1)
                    {
                        description += ", ";
                    }
                }
            }
            description += "\nWeapon: ";
            if (Weapon == null)
            {
                description += "There is no weapon in the room.";
            }
            else
            {
                description += Weapon.Name;
            }
            Description = description;
        }
        // Returns the description of the room after making sure that it is up to date with the current contents.
        public string GetDescription()
        {
            CreateDescription();
            return Description;
        }
        // Methods to remove items/monsters from the room.
        public void RemoveWeapon()
        {
            Weapon = null;
        }
        public void RemovePotion(int index)
        {
            Potions.RemoveAt(index);
            if (Potions.Count == 0)
            {
                Potions = null;
            }
        }
        public void RemoveMonster()
        {
            Monster = null;
        }
        public bool IsEmpty()
        {
            return Monster == null && Potions == null && Weapon == null;
        }
    }
}