using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player1;
        private Room currentRoom;
        static Random rnd = new Random();

        public Game()
        {
            // Initialize the game with one room and one player

            player1 = new Player("", 0, new List<string>());
            currentRoom = new Room("", false);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here

                //Instantiating player object
                Console.WriteLine("Enter the player's name: ");
                player1.Name = Console.ReadLine();

                player1.Health = 100;

                player1.Inventory = new List<string>();

                Console.WriteLine($"Player's name is: {player1.Name} \n{player1.Name}'s health is: {player1.Health} \nInventory is empty\nPress any key to begin your adventure...");
                Console.ReadKey();

                int roomNum = rnd.Next(1, 4);
                switch (roomNum)
                {
                        case 1:
                            currentRoom.Description = "You enter a small, dimly lit room. There is a small health potion placed on a table in the far left corner.";
                            break;
                        case 2:
                            currentRoom.Description = "You enter a completely dark room. It is impossible to see anything. Your fumble around in the darkness searching for a door to the next room.";
                            break;
                        case 3:
                            currentRoom.Description = "You enter a large, brightly lit room. There is a large health potion hidden under a cloth in the near left corner of the room.";
                            break;
                        case 4:
                            currentRoom.Description = "You emerge into blinding sunlight. You have escaped the dungeon!";
                            break;
                }
                int monsterPresent = rnd.Next(1, 2);
                if (monsterPresent == 1)
                {
                    currentRoom.Monster = true;
                    Console.WriteLine("There is a monster");
                    Console.ReadKey();
                }
                    else if (monsterPresent == 2)
                {
                    currentRoom.Monster = false;
                    Console.WriteLine("There is no monster");
                    Console.ReadKey();
                }

                Console.WriteLine(currentRoom.Description);
                Console.ReadKey();
            }
        }
    }
}
