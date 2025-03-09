﻿namespace DungeonExplorer
{
    public class Room
    {
        public Monster Monster { get; private set; }
        public Potion Potion { get; private set; }
        public Weapon Weapon { get; private set; }
        private string Description;

        public Room(Monster monster, Potion potion, Weapon weapon)
        {
            Monster = monster;
            Potion = potion;
            Weapon = weapon;
            Description = CreateDescription();
        }

        public string CreateDescription()
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
            description += "\nPotion: ";
            if (Potion == null)
            {
                description += "There is no potion in the room.";
            }
            else
            {
                description += Potion.Name;
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
            return description;
        }
        public string GetDescription()
        {
            return Description;
        }
    }
}