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
                    damageValue = 20;
                    break;
                case 4:
                    damageValue = 35;
                    break;
                case 5:
                    damageValue = 30;
                    break;
            }
            return damageValue;
        }

        public bool PlayerDeath()
        {
            if (player1.Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool creatingPlayer = true;
            bool playing = false;
            while (creatingPlayer)
            {
                // Code your playing logic here

                //Instantiating player object
                Console.WriteLine("Enter the player's name: ");
                player1.Name = Console.ReadLine();

                player1.Health = 100;

                player1.Inventory = new List<string>();

                Console.WriteLine($"Player's name is {player1.Name} \n{player1.Name}'s health is: {player1.Health} \nInventory is empty\nPress any key to begin your adventure...");
                Console.ReadKey();
                creatingPlayer = false;
            }

            playing = true;
            int roomsPassed = 0;
                while (playing == true)
                {
                    currentRoom.Description = currentRoom.ChooseRoom();
                    Console.WriteLine(currentRoom.Description);
                    Console.ReadKey();

                    int monsterPresent = rnd.Next(1, 3);
                if (monsterPresent == 1)
                {
                    currentRoom.Monster = true;
                    int damageValue = PlayerTakeDamage();
                    Console.WriteLine($"There is a monster in this room! {player1.Name} has taken {damageValue} damage!");
                    player1.Health = player1.Health - damageValue;
                    Console.ReadKey();
                    if (PlayerDeath() == true)
                    {
                        Console.WriteLine($"GAME OVER! {player1.Name} has died...");
                        playing = false;
                    }
                    else
                    {
                        roomsPassed++;
                    }
                    if (roomsPassed >= 10)
                    {
                        Console.WriteLine($"CONGRATULATIONS {player1.Name} YOU HAVE ESCAPED THE DUNGEON! You had {player1.Health} health points remaining");
                        playing = false;
                        Console.ReadKey();
                    }
                }
                else if (monsterPresent == 2)
                {
                    currentRoom.Monster = false;
                    Console.WriteLine("There is no monster in this room!");
                    roomsPassed++;
                    if (roomsPassed >= 10)
                    {
                        Console.WriteLine($"CONGRATULATIONS {player1.Name} YOU HAVE ESCAPED THE DUNGEON! You had {player1.Health} health points remaining");
                        playing = false;
                        Console.ReadKey();
                    }
                }
                }
                
            
        }
    }
}


