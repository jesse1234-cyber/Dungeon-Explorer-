using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Main program class containing the entry point for the application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point for the application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                // Check for test mode
                bool testMode = false;
                if (args.Length > 0 && args[0].Equals("-test", StringComparison.OrdinalIgnoreCase))
                {
                    testMode = true;
                    Console.WriteLine("Running in test mode...");
                    Testing.RunTests();
                }
                else
                {
                    // Normal game mode
                    Console.WriteLine("=== DUNGEON EXPLORER ===");
                    Console.WriteLine("A text-based adventure game");
                    Console.WriteLine();
                    
                    Game game = new Game();
                    game.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                Console.WriteLine("The game has encountered a problem and must close.");
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
