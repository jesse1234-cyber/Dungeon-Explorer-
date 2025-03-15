using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Game and start it
            Game game = new Game();
            game.Start();

            // Informing the player that the game has ended
            Console.Clear();
            Console.WriteLine("Game Over! Thank you for playing.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}