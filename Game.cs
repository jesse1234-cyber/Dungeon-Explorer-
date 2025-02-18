using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        // Game's Properties
        public Player Player { get; set; }
        public bool IsGameOver { get; set; }
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
            while (!IsGameOver)
            {
                Console.WriteLine();
                Player.CurrentRoom.GetDescription();
                Console.Write("\nWhat do you want to do?\n1. Move to another room\n2. Pick up items\n3. View player stats\n4. Display the Map\n5. Quit\n: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Player.MoveToRoom(Grid, Player.CurrentRoom.RoomCount);
                        break;
                    case "2":
                        Player.PickUpItem();
                        break;
                    case "3":
                        Player.DisplayInfo();
                        break;
                    case "4":
                        Player.DisplayMap(Grid);
                        break;
                    case "5":
                        IsGameOver = true;
                        Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}