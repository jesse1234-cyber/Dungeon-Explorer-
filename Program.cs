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
            Console.WriteLine("===== Dungeon Crawler =====\n");

            // Creates an empty grid of rooms
            int gridSize = 20;
            Room[,] grid = new Room[gridSize, gridSize];

            // Creates starting room
            int startX = gridSize / 2;
            int startY = gridSize / 2;
            Room startRoom = new Room("Room 0", "You wake up in a dark room, it seems that there is a weapon on the ground and one door to the North", 0);
            var startingWeapon = GameData.GetRandomWeapon(0, 3);
            startRoom.AddItem(startingWeapon.Key);
            startRoom.AddExit("North");
            grid[startX, startY] = startRoom;

            // Create a new player
            Player player = null;
            while (true)
            {
                Console.Write("Enter your name: ");
                string playerName = Console.ReadLine();
                if (playerName.Length > 0)
                {
                    player = new Player(playerName, startX, startY, startRoom);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid name.");
                }
            }

            // Creates a new game
            Game game = new Game(player, startRoom, grid);
            game.Start();

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
