using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Test
    {
        Player _player { get; set; }
        Room _room { get; set; }
        Combat _combat { get; set; }
        public Test(Player player, Room room, Combat combat) 
        { 
            _player = player;
            _room = room;
            _combat = combat; 
        }
        public Test(Player player, Room room)
        {
            _player = player;
            _room = room;
        }
        public Test(Room room)
        {
            _room = room;
        }
        public void RunForPlayer() 
        {
            System.Diagnostics.Debug.Assert(_player != null, "player character is null!");
            System.Diagnostics.Debug.Assert(_player.Stamina != 0, "Player should be dead!");
            System.Diagnostics.Debug.Assert(_player.Inventory != null, "player.Inventory is null!");
            System.Diagnostics.Debug.Assert(_player.WeaponInventory != null, "player.WeaponInventory is null!");
        }
        public void RunForRoom() 
        {
            System.Diagnostics.Debug.Assert(_room != null, "room is null!");
            System.Diagnostics.Debug.Assert(_room.ItemList != null, "ItemList is null!");
            System.Diagnostics.Debug.Assert(_room.ItemList.Count >= 3, "Items in the room must number at least three if there is any chance of combat occuring else an ArgumentNullException will occur for the 6th element of jinxedMisses.");
            System.Diagnostics.Debug.Assert(_room.FeatureList != null, "FeatureList is null!");
            System.Diagnostics.Debug.Assert(_room.FeatureList.Count >= 4, "Features must number 4 or more or else ArgumentNullException occurs for Jinxed Misses during Weapon.Attack()");
            System.Diagnostics.Debug.Assert(Regex.Matches(_room.Description, "\n").Count == 4, "room.Investigate() will not work unless there are a specific number of newlines");
            System.Diagnostics.Debug.Assert(Regex.Matches(_room.Description, "\t").Count == 5, "room.Investigate() will not work unless there are a specific number of tabs");
        }
        public void RunForCombat()
        {
            System.Diagnostics.Debug.Assert(_combat.Monster.Items.Contains(_combat.Monster.Veapon) || _combat.Monster.Veapon.Name == "gnashing maw" || _combat.Monster.Veapon.Name == "deadly claws", "Monster's weapons should be available upon searching monster after combat unless weapon was innate to the monster.");
        }
    }
}
