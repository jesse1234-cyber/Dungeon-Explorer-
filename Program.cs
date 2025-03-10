using System;


namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Dungeon, Adventurer.");
            // Start the game
            Game game = new Game();
            game.Start();
            Console.ReadKey();
        }
    }
}
