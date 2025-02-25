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
            try
            {
                Console.WriteLine("Welcome to dungeon explorer");
                Game game = new Game();
                game.Start();
            }

            catch (Exception)
            {
                Console.WriteLine("Error has Occured");
            }

            finally
            {
                Console.WriteLine("Waiting for your Implementation");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
