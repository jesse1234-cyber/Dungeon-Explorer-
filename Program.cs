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
                Game game = new Game();
                game.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("thanks for playing!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

