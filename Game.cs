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
                Console.WriteLine("A. Look around the room.");
                Console.WriteLine("B. Display status.");
                Console.WriteLine("Please enter a listed value to continue... ");
                bool loop = true;
                
                
                while (loop == true)
                {
                    string valueTest = Console.ReadKey().Key;
                    Console.WriteLine("That is not a valid input");

                    if (valueTest = ConsoleKey.A)
                    {
                        Console.Write(this.currentRoom.GetDescription());
                    }
                    else if (valueTest = ConsoleKey.B)
                    {
                        Console.Write(this.player.GetStatus());
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