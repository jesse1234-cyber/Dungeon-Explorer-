using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Setting up console color for better visibility
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Dungeon Explorer!");

                // Initialize and start the game
                Game game = new Game();
                game.Start();
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }
            finally
            {
                // Ensure the console color is reset before exiting
                Console.ResetColor();
                Console.WriteLine("\nGame Over! Thank you for playing Dungeon Explorer.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
