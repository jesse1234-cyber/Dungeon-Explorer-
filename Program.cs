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
            Game currentGame = new Game();
            currentGame.Start();
            Console.WriteLine("\nStopped the game!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("See you later :D");
        }
    }
}
