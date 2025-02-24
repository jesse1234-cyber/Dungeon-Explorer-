using System;
using System.Collections.Generic;
using System.Media;
using DungeonExplorer;

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

        public int PlayerTakeDamage()
        {
            int damageValue = 0;
            int randomDamage = rnd.Next(1, 6);
            switch (randomDamage)
            {
                case 1:
                    damageValue = 0;
                    break;
                case 2:
                    damageValue = 5;
                    break;
                case 3:
                    damageValue = 10;
                    break;
                case 4:
                    damageValue = 20;
                    break;
                case 5:
                    damageValue = 30;
                    break;
            }
            return damageValue;
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

                Console.WriteLine($"Player's name is {player1.Name} \n{player1.Name}'s health is: {player1.Health} \nInventory is empty\nPress any key to begin your adventure...");
                Console.ReadKey();
                bool playerCreated = true;

                while (playerCreated)
                {


                    int roomNum = rnd.Next(1, 5);
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
                            playerCreated = false;
                            playing = false;
                            break;
                    }

                    Console.WriteLine(currentRoom.Description);
                    Console.ReadKey();

                    int monsterPresent = rnd.Next(1, 3);
                    if (monsterPresent == 1 && roomNum != 4)
                    {
                        currentRoom.Monster = true;
                        int damageValue = PlayerTakeDamage();
                        Console.WriteLine($"There is a monster in this room! {player1.Name} has taken {damageValue} damage!");
                        player1.Health = player1.Health - damageValue;
                        Console.ReadKey();
                    }
                    else if (monsterPresent == 2 || roomNum == 4)
                    {
                        if (roomNum == 4)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            currentRoom.Monster = false;
                            Console.WriteLine("There is no monster in this room!");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}


