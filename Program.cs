using System;


namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start the game
            Game game = new Game();
            game.Start();
            Console.ReadKey();
        }
    }
}
