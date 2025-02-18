using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Room room = new Room("Dungeon Entrance: An eary aura roams through the path in front of you with you being able to sense the danger upahead. ");
            room.GetDescription();
            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }
    }
}
