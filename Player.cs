using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private Dictionary<string, Item> _inventory = new Dictionary<string, Item>();
        public int BaseDamage { get; private set; }

        public Player(string name, int health, int baseDamage)
        {
            Name = name;
            Health = health;
            BaseDamage = baseDamage;
        }

        public void PickUpItem(Item item)
        {
            if (item != null)
            {
                _inventory[item.Name] = item;
                Console.WriteLine($"{Name} picked up: {item.Name}");
            }
            else
            {
                Console.WriteLine("There is nothing to pick up.");
            }
        }

        public void TakeDamage(int damage)
        {
            int totalArmor = GetTotalArmor();
            double damageReduction = totalArmor / 100.0;
            int reducedDamage = (int)(damage * (1 - damageReduction));
            Health -= reducedDamage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} took {reducedDamage} damage (reduced by {totalArmor}%). Health is now {Health}.");
        }

        public void Heal()
        {
            if (_inventory.Values.Any(item => item.Healing > 0))
            {
                var bestItem = _inventory.Values
                    .Where(item => item.Healing > 0)
                    .OrderBy(item => item.Healing)
                    .FirstOrDefault(item => Health + item.Healing <= 100) ?? 
                    _inventory.Values.Where(item => item.Healing > 0).OrderByDescending(item => item.Healing).First();

                Health += bestItem.Healing;
                if (Health > 100) Health = 100; // Cap health at 100
                _inventory.Remove(bestItem.Name);
                Console.WriteLine($"{Name} healed with a {bestItem.Name}. Health is now {Health}.");
            }
            else
            {
                Console.WriteLine("No healing items to heal with.");
            }
        }
        
        public string InventoryContents()
        {
            if (_inventory.Count == 0)
            {
                return "Inventory is empty.";
            }

            List<string> contents = new List<string>();
            foreach (var item in _inventory.Values)
            {
                List<string> itemStats = new List<string>();
                if (item.Armor > 0) itemStats.Add($"Armor: {item.Armor}");
                if (item.Healing > 0) itemStats.Add($"Healing: {item.Healing}");
                if (item.Damage > 0) itemStats.Add($"Damage: {item.Damage}");

                if (itemStats.Count > 0)
                {
                    contents.Add($"{_inventory.Values.Count(i => i.Name == item.Name)}x {item.Name} ({string.Join(", ", itemStats)})");
                }
            }
            return string.Join("\n", contents);
        }

        public bool HasItem(string itemName)
        {
            return _inventory.ContainsKey(itemName);
        }

        public int GetItemDamage(string itemName)
        {
            return _inventory.ContainsKey(itemName) ? _inventory[itemName].Damage : 0;
        }

        public int GetMaxDamage()
        {
            return _inventory.Values.Any() ? Math.Max(BaseDamage, _inventory.Values.Max(item => item.Damage)) : BaseDamage;
        }

        public string GetMaxDamageItem()
        {
            return _inventory.Values.Any() ? _inventory.Values.OrderByDescending(item => item.Damage).FirstOrDefault()?.Name : null;
        }

        public int GetTotalArmor()
        {
            return _inventory.Values.Sum(item => item.Armor);
        }

        public string GetArmorItems()
        {
            return string.Join(", ", _inventory.Values.Where(item => item.Armor > 0).Select(item => item.Name));
        }

        public string GetStats()
        {
            int maxDamage = GetMaxDamage();
            string maxDamageItem = GetMaxDamageItem();
            int totalArmor = GetTotalArmor();
            string armorItems = GetArmorItems();

            string damageStat = maxDamage > 0 ? $"Damage: {maxDamage} ({maxDamageItem})" : "Damage: 0";
            string armorStat = totalArmor > 0 ? $"Armor: {totalArmor} ({armorItems})" : "Armor: 0";

            return $"{damageStat}\n{armorStat}";
        }
    }
}