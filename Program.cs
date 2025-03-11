using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dungeon_Explorer.Program;

namespace Dungeon_Explorer
{
    public class Program
    {

        public class Game
        {
            public static void Main(string[] args)
            {
                {
                    Player player = new Player();
                    Console.WriteLine("The player's name is: " + player.Player_Name);
                    // The code below is to create a room.
                    Room room = new Room();
                }
            }
        }

        public class Player
        {
            public string Player_Name;

            public Player()
            {

                Console.WriteLine("Please enter your name: ");
                Player_Name = Console.ReadLine();
                Console.WriteLine("Hello, " + Player_Name);
            }

            public class Inventory<T>
            {
                private List<T> items;

                public Inventory()
                {
                    items = new List<T>();

                    Console.WriteLine("Inventory stuff: ");
                    foreach (var item in items)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }


        public class Room
        {
            public string Room_Description = "This is some test text.";
            public string Item { get; set; } = "Apple.";

            public Room()
            {
                Console.WriteLine("Room description: " + Room_Description);
                Console.WriteLine("You have picked up an item: Apple.");
            }

            // public static void Main(string[] args)
            // {
            // Room room = new Room();
            // }
        }
    }
}
