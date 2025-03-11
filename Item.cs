using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;


namespace DungeonExplorer
{
    
    public enum ItemType { HealSpell, IgnoranceSpell, EliminationSpell, Weapon}
    public enum Rarity { Common, Rare, Legendary }
    
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public Rarity Rarity { get; }
        public static bool skipBattle { get; set; }

        public Item(string name, ItemType type, Rarity rarity)
        {
            Name = name;
            Type = type;
            Rarity = rarity;
        }

        public void UseItem(Player player)
        {
            
            if (player.inventoryItem == null)
            {
                Console.WriteLine("You don’t have any items to use.");
                return;
            }
            switch (Type)
            {
                case ItemType.HealSpell:
                    if (player.FirstRoom)
                    {
                        Console.WriteLine("You can't use heal spell at the start.");
                    }
                    else
                    {
                        player.SetHealth(player.GetHealth() + 20);
                        Console.WriteLine($"You used {Name}. Health is increased by 20.");
                    }
                    break;
                
                case ItemType.IgnoranceSpell:
                    Console.WriteLine($"You used {Name}. You skipped all the enemies by becoming invisible.");
                    skipBattle = true;
                    return;
                case ItemType.EliminationSpell:
                    Console.WriteLine($"You used {Name}. You eliminated all enemies.");
                    skipBattle = true;
                    return;
                case ItemType.Weapon:
                    Console.WriteLine($"You used {Name}. It will be helpful in fights.");
                    break;
            }
            Console.WriteLine($"You used {player.inventoryItem.Name}");
            player.inventoryItem = null; // Remove the item after use
            
        }

        public override string ToString()
        { // Custom implementation of return object. 
            return $"{Name} ({Rarity})";
        }
    }
}