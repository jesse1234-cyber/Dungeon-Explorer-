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
        public string Contents()
        {
            return string.Join(", ", Weapon.Select(w => w.Name).Concat(Potion.Select(p => p.Name)));
        }
    }
}
