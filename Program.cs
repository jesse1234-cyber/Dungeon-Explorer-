using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// The main entry point for the Dungeon Explorer game.
    /// Initializes the game and starts the gameplay loop.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// Creates a new game instance, starts the game, and waits for user input before exiting.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this case).</param>
        static void Main(string[] args)
        {
            // Create a new instance of the Game class
            Game game = new Game();
            
            // Start the game, which enters the game loop
            game.Start();

            // Inform the user to press any key to exit the program once the game is finished
            Console.WriteLine("Press any key to exit...");

            // Wait for the user to press a key before the application closes
            Console.ReadKey();
        }
    }
}

