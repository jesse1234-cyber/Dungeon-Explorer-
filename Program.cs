using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            // Prompt for player name
            string playerName;
            do
            {
                Console.Write("Enter player name (max 10 characters): ");
                playerName = Console.ReadLine();
            } while (string.IsNullOrEmpty(playerName) || playerName.Length > 10);

            // Initialize the game with one player and four rooms
            Player player = new Player(playerName, 100, 10);
            Game game = new Game(player);
            game.InitializeRooms();
            bool playerWon = game.Start();

            // Display the result
            if (playerWon)
            {
                Console.WriteLine("Congratulations! You found the treasure! You win!");
            }
            else
            {
                Console.WriteLine("You have been defeated or quit the game. Better luck next time!");
            }

            Console.WriteLine("Game Over");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}