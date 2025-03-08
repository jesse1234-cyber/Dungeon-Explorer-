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
                Game game = new Game(); // Create a game object
                game.Start();   // Runs it
            }
            catch(Exception ex) // Error check, if an exception is thrown, a message is displayed
            {
                Console.WriteLine($"An error occurred {ex.Message}");
            }
            finally // Once the game is finished running, we await for a user key input and end the program
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
