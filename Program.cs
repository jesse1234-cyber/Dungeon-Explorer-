using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {                                    
            Room roomLeft = new Room("You have just entered the Spider Dungeon and a boulder has blocked the exit! \n Within this room you notice cobwebs across the floors and ceiling \n and have noticed a small dark passageway heading forwards... ");
            Room roomRight = new Room("You have just entered the Snake Dungeon and the exit has been blocked by a large boulder! \n Within this room you notice a small layer of water along the floor, slimy liquid dripping from the ceilings \n and a small dark passageway heading forwards... ");
            Game.GameStart();
            Game.Maingameloop();
        }   
    }
}
