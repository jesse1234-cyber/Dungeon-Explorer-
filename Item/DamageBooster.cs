using System;
using DungeonExplorer.Player;

namespace DungeonExplorer.Item.Items {
    
    /// Represents a Damage Booster item.
    
    public class DamageBooster : Item {
        private const int PlayerDamage + 10;

        
        /// Initializes a new instance of the DamageBoost class.
        
        public DamageBooster() : base("Damage Talisman", "increases damage.", true)
        {
            // ID is automatically assigned in the base class constructor
        }

        
        /// Uses the Damage booster on the player.
        
        /// <param name="player">The player to use the Talisman on.</param>
        public override void Use(Player.Player player)
        {
            if (!(player.Damage == player.getMaxDamage()))
            {
                Console.WriteLine("You Take the Damage Talisman and feel Stonger!");
                Console.WriteLine("[+10 DMG]");
                player.AddDamage(DamageUp);
                player.RemoveItem(this);
            }
            else
            {
                Console.WriteLine("You are already wearing a talisman");
            }
        }
    }
}

