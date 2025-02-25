using System;
using System.Linq;
using System.Media;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        // Game's Properties
        public Player Player { get; set; }
        public static bool IsGameOver { get; set; }
        public Room[,] Grid { get; set; }

        // Game's constructor
        public Game(Player player, Room currentRoom, Room[,] grid)
        {
            Player = player;
            IsGameOver = false;
            Grid = grid;
        }

        // Main game loop
        public void Start()
        {
            bool DisplayInfo = false;
            bool DisplayMap = false;
            Console.WriteLine("\nStarting Game...\n");
            Thread.Sleep(400);
            while (!IsGameOver)
            {
                Thread.Sleep(100);
                Console.Clear();
                Player.CurrentRoom.GetDescription();
                if (DisplayInfo)
                {
                    Player.DisplayInfo();
                    DisplayInfo = false;
                }
                if (DisplayMap)
                {
                    Player.DisplayMap(Grid);
                    DisplayMap = false;
                }
                Console.Write("\nWhat do you want to do?\n\n1. Move to another room\t\t" +
                    "2. Fight!\n3. Pick up items\t\t4. View player stats\n5. Display the Map\t\t6. Quit\n: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Player.MoveToRoom(Grid, Player.CurrentRoom.RoomCount);
                        break;
                    case "2":
                        Player.FightEnemy();
                        break;
                    case "3":
                        Player.PickUpItem();
                        break;
                    case "4":
                        DisplayInfo = true;
                        break;
                    case "5":
                        DisplayMap = true;
                        break;
                    case "6":
                        IsGameOver = true;
                        Console.WriteLine("\nThanks for playing!\n");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Try again.\n");
                        break;
                }
            }
        }
    }
}
