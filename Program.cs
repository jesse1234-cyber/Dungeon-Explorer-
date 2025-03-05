using System;

namespace DungeonExplorer
{
    internal class Program
    {
        private const int GridSize = 20;
        private const int MinWeaponLevel = 0;
        private const int MaxWeaponLevel = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("===== Dungeon Crawler =====\n");

            // Creates an empty grid of rooms
            var grid = new Room[GridSize, GridSize];

            // Creates starting room
            int startX = GridSize / 2;
            int startY = GridSize / 2;
            var startRoom = CreateStartingRoom();
            grid[startX, startY] = startRoom;

            // Create a new player
            var player = CreatePlayer(startX, startY, startRoom);

            // Creates a new game
            var game = new Game(player, startRoom, grid);
            game.Start();

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static Room CreateStartingRoom()
        {
            var startRoom = new Room("Room 0", "You wake up in a dark room, it seems that there is a weapon on the ground and one door to the North", 0);
            var startingWeapon = GameData.GetRandomWeapon(MinWeaponLevel, MaxWeaponLevel);
            startRoom.AddItem(startingWeapon.Key);
            startRoom.AddExit("North");
            return startRoom;
        }

        private static Player CreatePlayer(int startX, int startY, Room startRoom)
        {
            string playerName;
            do
            {
                Console.Write("Enter your name: ");
                playerName = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Please enter a valid name.");
                }
            } while (string.IsNullOrEmpty(playerName));

            return new Player(playerName, startX, startY, startRoom);
        }
    }
}