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

        // Method that starts the game
        public void Start()
        {
            bool DisplayInfo = false;
            bool DisplayMap = false;
            Console.WriteLine("\nStarting Game...\n");
            Thread.Sleep(400);

            // Main game loop
            while (!IsGameOver)
            {
                Thread.Sleep(100);
                Console.Clear();

                // Gets the room information
                Player.CurrentRoom.GetDescription();

                // Displays relavant information if needed
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

                // Asks the player what they want to do
                Console.Write("\nWhat do you want to do?\n\n1. Move to another room\t\t" +
                    "2. Fight!\n3. Pick up items\t\t4. Use Items\n5. View player stats\t\t6. Display the Map\n7. Quit\n: ");
                string choice = Console.ReadLine();

                // Switch statement to handle the player's choice
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
                        Player.UseItem();
                        break;
                    case "5":
                        DisplayInfo = true;
                        break;
                    case "6":
                        DisplayMap = true;
                        break;
                    case "7":
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
