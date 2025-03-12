using System;

namespace DungeonExplorer
{
    /// <summary>
    /// A class that initialises the game environment by instantiating a <see cref="Game"/> object,
    /// and also handles what happens when the user chooses to leave the game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Creates a new Game object and begins the game by calling the Start method. 
        /// Handles user exit and displays corresponding messages.
        /// </summary>
        /// <param name="args">String array that stores the command-line arguments.</param>
        static void Main(string[] args)
        {
            //TestProgram testingInstance = new TestProgram();
            //testingInstance.TestPlayer();
            //testingInstance.TestRoom();

            try
            {
                // Create a new game instance
                Game currentGame = new Game();
                // Start the game
                currentGame.Start();
            }
            finally
            {
                Console.WriteLine("\nStopped the game!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Console.WriteLine("See you later :D");
            }
        }
    }
}

