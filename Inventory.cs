using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Weapon> Weapon = new List<Weapon>();
        private List<Potion> Potion = new List<Potion>();
        // Methods for accessing information about inventory contents.
        public int WeaponCount()
        {
            return Weapon.Count;
        }
        public int PotionCount()
        {
            return Potion.Count;
        }
        public Weapon GetWeapon(int index)
        {
            return Weapon[index];
        }
        public Potion GetPotion(int index)
        {
            return Potion[index];
        }
        public void AddWeapon(Weapon weapon)
        {
            Weapon.Add(weapon);
        }
        public void AddPotion(Potion potion)
        {
            Potion.Add(potion);
        }
        public void RemoveWeapon(Weapon weapon)
        {
            Weapon.Remove(weapon);
        }
        public void RemovePotion(Potion potion)
        {
            Potion.Remove(potion);
        }
        // Method returns the contents of the inventory.
        public string Contents()
        {
            string contents = "";
            if (WeaponCount() > 0)
            {
                contents += "\nWeapons:\n";
                for (int i = 0; i < Weapon.Count; i++)
                {
                    contents += $"{i + 1}) {Weapon[i].Name} \n";
                }
            }
            if (PotionCount() > 0)
            {
                contents += "\nPotions:\n";
                for (int i = 0; i < Potion.Count; i++)
                {
                    contents += $"{i + 1}) {Potion[i].Name} \n";
                }
            }
            if (contents == "")
            {
                contents = "\nYour inventory is empty.\n";
            }
            return contents;
        }
    }
}
