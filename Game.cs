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
            currentRoom = new Room("", false, "");

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

        public bool ItemGeneration()
        {
            bool isItem = false;
            int randomItem = rnd.Next(1, 3);
            if (randomItem == 1)
            {
                isItem = true;
            }
            else if (randomItem == 2)
            {
                isItem = false;
            }
            return isItem;
        }

        public void UseItem(List<string> inventory)
        {
            Console.WriteLine("Enter the name of the item you want to use: ");
            string itemUsed = Console.ReadLine().ToLower();
            if (inventory.Contains(itemUsed))
            {
                if (itemUsed == "small health potion")
                {
                    if (player1.Health <= 95)
                    {
                        player1.Health += 5;
                        player1.Inventory.Remove(itemUsed);
                        Console.WriteLine($"{player1.Name}'s health has been increased by 5hp \n{player1.Name}'s current health: {player1.Health}");
                    }
                    else
                    {
                        Console.WriteLine($"{player1.Name}'s health is too high to use this potion");
                    }

                }
                else if (itemUsed == "regular health potion")
                {
                    if (player1.Health <= 90)
                    {
                        player1.Health += 10;
                        player1.Inventory.Remove(itemUsed);
                        Console.WriteLine($"{player1.Name}'s health has been increased by 10hp \n{player1.Name}'s current health: {player1.Health}");
                    }
                    else
                    {
                        Console.WriteLine($"{player1.Name}'s health is too high to use this potion");
                    }

                }
                else if (itemUsed == "large health potion")
                {
                    if (player1.Health <= 80)
                    {
                        player1.Health += 20;
                        player1.Inventory.Remove(itemUsed);
                        Console.WriteLine($"{player1.Name}'s health has been increased by 20hp \n{player1.Name}'s current health: {player1.Health}");
                    }
                    else
                    {
                        Console.WriteLine($"{player1.Name}'s health is too high to use this potion");
                    }
                }
            }
            else
            {
                Console.WriteLine($"You do not have any {itemUsed}s left in your inventory, you get frustrated and move on");

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
                Console.WriteLine("Game rules: \nYou have been stranded in a dungeon. To escape you must pass through 10 \nrooms, fighting any monsters you may come across... \nPress any key to continue");
                Console.ReadKey();
                Console.WriteLine("When you enter each room you will search it for monsters or items. \nMonsters may damage you and you will lose health points \nItems such as health potions will replenish your health when consumed");
                Console.ReadKey();
                Console.WriteLine("Potions: \nSmall health potion: grants 5 health points when consumed\nRegular health potion: grants 10 health points when consumed \nLarge health potion: grants 20 health points when consumed");
                Console.ReadKey();
                Console.WriteLine($"Now, {player1.Name}, your adventure begins. Good luck!");
                Console.ReadKey();
                Console.WriteLine($"Player's name is {player1.Name} \n{player1.Name}'s health is: {player1.Health} \nInventory is empty\nPress any key to begin your adventure...");
                Console.ReadKey();
                creatingPlayer = false;
            }

            playing = true;
            int roomsPassed = 0;
            while (playing == true)
            {
                Console.WriteLine($"Do you want to view {player1.Name}'s status or move on to the next room? \nType 'S' to view player status or 'C' to continue: ");
                string playerChoice = Console.ReadLine().ToUpper();
                if (playerChoice == "S")
                {
                    Console.WriteLine($"{player1.Name}'s health = {player1.Health} health points \n{player1.Name}'s inventory consists of: {player1.InventoryContents()} ");
                }
                else if (playerChoice == "C")
                {
                    Console.WriteLine("Would you like to use an item from your inventory? (Enter 'yes' or 'no') \n");
                    string playerUseitem = Console.ReadLine().ToLower();
                    if (playerUseitem == "yes")
                    {
                        UseItem(player1.Inventory);
                    }
                    else if (playerUseitem == "no")
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection, confused, you continue through the dungeon");
                    }
                    currentRoom.Description = currentRoom.ChooseRoom();
                    Console.WriteLine(currentRoom.Description);
                    Console.ReadKey();

                    if (ItemGeneration() == true)
                    {
                        currentRoom.Item = currentRoom.ChooseItem();
                        player1.PickUpItem(currentRoom.Item);
                        Console.WriteLine($"{player1.Name} searches the room and finds a {currentRoom.Item} \nThis has been added to your inventory \nPress any key to continue");
                        Console.ReadKey();
                        Console.WriteLine(player1.InventoryContents());
                    }
                    else
                    {
                        Console.WriteLine($"{player1.Name} searches the room but finds no items \nPress any key to continue");
                        Console.ReadKey();
                    }
                    int monsterPresent = rnd.Next(1, 3);
                    if (monsterPresent == 1)
                    {
                        currentRoom.Monster = true;
                        int damageValue = PlayerTakeDamage();
                        Console.WriteLine($"There is a monster in this room!");
                        Console.WriteLine("Press any key to fight the monster!");
                        Console.ReadKey();
                        Console.WriteLine($"{player1.Name} attacks the monster! \n{player1.Name} takes {damageValue} damage from the battle!");
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
}


