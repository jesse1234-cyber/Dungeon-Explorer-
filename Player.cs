using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Dictionary<ItemType, int> Inventory { get; } = new Dictionary<ItemType, int>();
        
        private bool _shieldEquipped = false;
        public bool HasBadLuck = false;

        public Player(string name) 
        {
            Name = name;
            Health = 100;
        }
        
        public string InventoryContents()
        {
            List<string> items = new List<string>();
            foreach (var inventoryItems in Inventory)
            {
                int itemCount = inventoryItems.Value;
                if (itemCount == 0)
                    continue;
                    
                ItemType itemType = inventoryItems.Key;
                items.Add($"{itemCount}x {itemType.ToString()}");
            }
            
            return string.Join(", ", items);
        }
        
        public void PickUpItem(ItemType item)
        {
            if (Inventory.ContainsKey(item))
            {
                Inventory[item] += 1;
                return;
            }
            
            Inventory.Add(item, 1);
        }

        public bool HasItem(ItemType item)
        {
            return Inventory.ContainsKey(item) && Inventory[item] != 0;
        }

        public void UseItem(ItemType item)
        {
            switch (item)
            {
                case ItemType.HealthPotion:
                    AddHealth(30);
                    break;
                case ItemType.Shield:
                    if (_shieldEquipped)
                    {
                        Console.WriteLine("You already have a shield equipped. Equip another shield when the currently equipped shield is used.");
                        return;
                    }

                    _shieldEquipped = true;
                    break;
                case ItemType.EscapeCode:
                    Console.WriteLine("You have escaped the dungeon and won the game, congratulations!");
                    Game.Quit();
                    break;
            }

            Inventory[item] -= 1;
        }
        
        private void RemoveHealth(int amount)
        {
            if (Health - amount < 0)
                Health = 0;
            else
                Health -= amount;
            
            Console.WriteLine($"You lost {amount} health. Your health is now {Health}%.");

            if (Health == 0)
            {
                Console.WriteLine("You died, better luck next time.");
                Game.Quit();
            }
        }

        private void AddHealth(int amount)
        {
            if (Health + amount > 100)
                Health = 100;
            else
                Health += amount;
            
            Console.WriteLine($"Your health is now {Health}%.");
        }

        public void GetAttacked(int healthLoss)
        {
            if (_shieldEquipped)
            {
                Console.WriteLine("You were attacked but your shield saved you from damage. You no longer have a shield equipped.");
                _shieldEquipped = false;
                return;
            }
            
            RemoveHealth(healthLoss);
        }

        public void GiveBadLuck()
        {
            HasBadLuck = true;
            Console.WriteLine($"You have been given bad luck.");
        }
        
        public void StealItem()
        {
            ItemType? stolenItem = null;
            
            foreach (var inventoryItem in Inventory)
            {
                ItemType itemType = inventoryItem.Key;
                int count = inventoryItem.Value;

                if (count == 0)
                    continue;
                
                Inventory[itemType] -= 1;
                stolenItem = itemType;
                break;
            }

            if (stolenItem == null)
            {
                Console.WriteLine("The thief attempted to steal from you however you had no items in your inventory.");
                return;
            }
            
            Console.WriteLine($"The thief stole 1x {stolenItem} from you.");
        }
    }
}