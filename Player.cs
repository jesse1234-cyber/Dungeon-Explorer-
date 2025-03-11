using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Player
    {
        //Player stats
        public string name;
        public int coins = 0;
        public int health = 10;
        public int roomCount = 0;

        //Player inventory
        public int armorValue = 0;
        public int potions = 3;
        public string weapon = "Rusty Sword";
        public int weaponValue = 1;
    }
}