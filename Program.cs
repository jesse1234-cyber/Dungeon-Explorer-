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
                    // The code below creates a "Monster" object.
                    Monster Room_1_Monster = new Monster();
                    // The code below is to create a room.
                    Room room = new Room(Room_1_Monster);
                    // The code below this has been commented out because it gave the user
                    // the same description as the first room.
                    // Monster_2 Room_2_Monster = new Monster_2();

                    // The code below is to add an additional room.
                    // Room_2 room_2 = new Room_2(Room_2_Monster);
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
                int Player_Health;
                Player_Health = 50;
                Console.WriteLine("Your Health is: " + Player_Health);
                Console.WriteLine("Pick a room to go into: (1/2)");
                Console.ReadLine();
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
            public string Room_Description = "You have entered a bleak, dark looking room.";
            public string Item { get; set; } = "Apple.";
            public Monster Room_1_Monster { get; set; }

            public Room(Monster Room_1_Monster = null)
            {
                Console.WriteLine("Room description: " + Room_Description);
                Console.WriteLine("You have picked up an item: Apple.");
                Room_1_Monster = Room_1_Monster;
                if (Room_1_Monster != null)
                {
                    Console.WriteLine("You have encountered a monster: " + Room_1_Monster.Monster_Description);
                }
            }
        }

        public class Monster
        {
            public string Monster_Description { get; set; } = "You have encountered an oversized frog.";

            public Monster()
            {
                Console.WriteLine("Monster_Description: " + Monster_Description);
            }
        }

        public class Room_2
        {
            public string Room_2_Description { get; set; } = "You have entered a room with bright lights.";

            public Room_2()
            {
                Console.WriteLine("Room_Description: " + Room_2_Description);
            }
        }

        // public class Monster_2
        // {
            // public string Monster_2_Description { get; set; } = "You have encountered a giant marshmellow monster.";

            // public Monster_2(Monster Room_2_Monster = null);
                // if (Room_2_Monster != null)
                // {
                    // Console.WriteLine("You have encountered a monster: " + Room_2_Monster.Monster_Description);
                // }
        }
    }
