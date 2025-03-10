using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player character in the game.
    /// </summary>
    public class Player : Entity
    {
        private Dictionary<string, Item> _inventory = new Dictionary<string, Item>();
        public int BaseDamage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="health">The health of the player.</param>
        /// <param name="baseDamage">The base damage of the player.</param>
        public Player(string name, int health, int baseDamage) : base(name, health)
        {
            BaseDamage = baseDamage;
        }

        /// <summary>
        /// Adds an item to the player's inventory.
        /// </summary>
        /// <param name="item">The item to pick up.</param>
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

        /// <summary>
        /// Heals the player using the best available healing item.
        /// </summary>
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

        /// <summary>
        /// Gets the contents of the player's inventory.
        /// </summary>
        /// <returns>A string representation of the inventory contents.</returns>
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

        /// <summary>
        /// Determines if the player has a specific item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns><c>true</c> if the player has the item; otherwise, <c>false</c>.</returns>
        public bool HasItem(string itemName)
        {
            return _inventory.ContainsKey(itemName);
        }

        /// <summary>
        /// Gets the damage value of a specific item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>The damage value of the item.</returns>
        public int GetItemDamage(string itemName)
        {
            return _inventory.ContainsKey(itemName) ? _inventory[itemName].Damage : 0;
        }

        /// <summary>
        /// Gets the maximum damage the player can deal.
        /// </summary>
        /// <returns>The maximum damage value.</returns>
        public int GetMaxDamage()
        {
            return _inventory.Values.Any() ? Math.Max(BaseDamage, _inventory.Values.Max(item => item.Damage)) : BaseDamage;
        }

        /// <summary>
        /// Gets the name of the item with the maximum damage.
        /// </summary>
        /// <returns>The name of the item with the maximum damage.</returns>
        public string GetMaxDamageItem()
        {
            return _inventory.Values.Any() ? _inventory.Values.OrderByDescending(item => item.Damage).FirstOrDefault()?.Name : null;
        }

        /// <summary>
        /// Gets the total armor value from all items in the inventory.
        /// </summary>
        /// <returns>The total armor value.</returns>
        public int GetTotalArmor()
        {
            return _inventory.Values.Sum(item => item.Armor);
        }

        /// <summary>
        /// Gets the names of all armor items in the inventory.
        /// </summary>
        /// <returns>A comma-separated string of armor item names.</returns>
        public string GetArmorItems()
        {
            return string.Join(", ", _inventory.Values.Where(item => item.Armor > 0).Select(item => item.Name));
        }

        /// <summary>
        /// Gets the player's statistics.
        /// </summary>
        /// <returns>A string representation of the player's statistics.</returns>
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