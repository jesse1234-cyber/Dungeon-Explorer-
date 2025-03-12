using System;

namespace DungeonExplorer
{
    /// <summary>
    /// The entry point of the program.
    /// It creates a new instance of the room, player and game classes and starts the game.
    /// </summary>
    internal class Program
    {
        private const int GridSize = 10;
        private const int MinWeaponLevel = 0;
        private const int MaxWeaponLevel = 3;

        /// <summary>
        /// Main method of the program.
        /// Creates a new instance of the room, player and game classes.
        /// Then starts the game.
        /// </summary>
        /// <param name="args"> Command-line arguments. </param>
        static void Main(string[] args)
        {
            // Testing
            //GameTests tests = new GameTests();
            //tests.RunAllTests();

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

        /// <summary>
        /// Creates the starting room for the game.
        /// </summary>
        /// <returns> A Room object that represents the starting room.</returns>
        private static Room CreateStartingRoom()
        {
            var startRoom = new Room("Room 0", "You wake up in a dark room, you read a sign on the wall \"You must survive 10 rooms to leave\"" +
                " it seems that there is a weapon on the ground and one door to the North", 0);
            var startingWeapon = GameData.GetRandomWeapon(MinWeaponLevel, MaxWeaponLevel);
            startRoom.AddItem(startingWeapon.Key);
            startRoom.AddExit("North");
            return startRoom;
        }

        /// <summary>
        /// Creates a new player for the game.
        /// </summary>
        /// <param name="startX"> The starting X-coordinate of the player on the grid.</param>
        /// <param name="startY"> The starting Y-coordinate of the player on the grid.</param>
        /// <param name="startRoom"> The starting room of the player.</param>
        /// <returns> A Player object representing the character the user will play.</returns>
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