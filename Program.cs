using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Starts game
                Game game = new Game();
                game.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                // Ends game
                Console.WriteLine("\nGame over. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
