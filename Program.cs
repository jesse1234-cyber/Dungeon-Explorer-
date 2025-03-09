using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setting up console color for better visibility
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Dungeon Explorer!");

            // Initialize the game
            Game game = new Game();
            game.Start();  // Starts the game logic

            // Display a message when the game ends or exits
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nGame Over! Thank you for playing Dungeon Explorer.");
            Console.WriteLine("Press any key to exit...");

            // Wait for the player to press a key to exit
            Console.ReadKey();
        }
    }
}
