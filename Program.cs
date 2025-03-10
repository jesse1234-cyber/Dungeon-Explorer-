using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializing player
            string playerName = "Player";
            Player player = new Player(playerName, 30, 0, 1);
            // Initializing starting room
            Room startingRoom = new Room(null, new Potion("Health(10) Potion", 0, 10, 0), new Weapon("Sword", 10));
            // Initializing and starting game
            Game game = new Game(player, startingRoom);
            Console.WriteLine("========Welcome to DUNGEON EXPLORER!========\n"); // Game title
            game.Start();
            Console.ReadKey();
        }
    }
}
