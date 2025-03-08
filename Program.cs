using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Program
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
            List<Room> rooms = new List<Room>
            {
                new Room("A dark cellar. There is a Goblin awaiting your approach.", new List<Item> { new Item("Rusty Knife", damage: 20), new Item("Apple", healing: 20) }, new List<Creature> { new Creature("Goblin", 30, 10) }, false),
                new Room("A damp cave. There is an Orc awaiting your approach.", new List<Item> { new Item("Shield", armor: 10), new Item("Potion", healing: 50), new Item("Apple", healing: 20) }, new List<Creature> { new Creature("Orc", 50, 20) }, false),
                new Room("A narrow corridor. There is a Skeleton awaiting your approach.", new List<Item> { new Item("Sword", damage: 30), new Item("Apple", healing: 20) }, new List<Creature> { new Creature("Skeleton", 40, 30) }, false),
                new Room("A treasure room. There is a Dragon awaiting your approach.", new List<Item> { new Item("Chestplate", armor: 30), new Item("Potion", healing: 50) }, new List<Creature> { new Creature("Dragon", 100, 40) }, true)
            };

            Game game = new Game(player, rooms);
            game.Start();
            Console.WriteLine("Game Over");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}