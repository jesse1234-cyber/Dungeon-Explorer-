using DungeonExplorer.Player;
using System;

// Item to add health to player
namespace DungeonExplorer.Item.Items {
    public class HealthPotion : Item {
        private const int HealthRegen = 3;

        public HealthPotion() : base("Health Potion", "Regenerates a small amount of health.", true)
        {
            // ID is automatically assigned in the base class constructor
        }


        // Use item on player
        public override void Use(Player.Player player)
        {

            if(!(player.Health >= player.getMaxHealth())) {
                Console.WriteLine("You drink the health potion!");
                Console.WriteLine("[+3 HP]");
                player.AddHealth(HealthRegen);

                // remove the potion from posession when used
                player.RemoveItem(this);


            }
            else
            {
                Console.WriteLine("You are already at max health.");
            }
        }
    }
}
