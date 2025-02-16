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
            // Initalise Game Class
            Game game = new Game();
            // Start the game
            game.Start();
            // End the game
            Console.WriteLine("Thanks For Playing");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
