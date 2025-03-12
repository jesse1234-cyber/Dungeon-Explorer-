using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            
            Console.WriteLine("To show the difference between 2 branches sdfgdhgfs");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
