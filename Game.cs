using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            this.player = new Player("Username", 100);
            string design = @"Before you is a large pair of oak doors,
                held together with wrought iron bolts, rusted due to time.
                Beside the doors, rests small lanterns, they look to have
                been untouched for years. The doors themsleves are inset into
                a marble frame, that itself looks remarkably clean in contrast
                to its surroundings.";
            design = design.Replace(System.Environment.NewLine, " ");
            this.currentRoom = new Room(design);
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("1. Look around the room.");
                Console.WriteLine("2. Display status.");
                Console.WriteLine("Please enter a listed value to continue... ");
                bool loop = true;
                
                
                while (loop == true)
                {
                    ConsoleKeyInfo valueTest = Console.ReadKey();
                    Console.WriteLine("That is not a valid input");

                    if ("1" == valueTest.KeyChar.ToString())
                    {
                        Console.Write(this.currentRoom.GetDescription());
                    }
                    else if ("2" == valueTest.KeyChar.ToString())
                    {
                        Console.Write(this.player.GetStatus());
                    }
                    else if ("3" == valueTest.KeyChar.ToString())
                    {
                        Console
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid input");
                    }
                }
            }
        }
    }
}