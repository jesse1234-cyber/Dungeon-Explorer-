using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Item> possibleItems;


        private void RestartGame()
        {
            Console.WriteLine("\nDo you want to restart the game? y/n");
            string choice  = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                Console.WriteLine("\nRestarting the game...");
                System.Threading.Thread.Sleep(1000); // delay ???
                Game newGame = new Game();
                newGame.Start();
            }
            else
            {
                Console.WriteLine("\nThanks for playing!");
                Environment.Exit(0);
            }
        }
        public List<Enemy> GenerateEnemies()
        {
            Random rndm = new Random();
            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < 3; i++)
            {
                enemies.Add(new Enemy((EnemyClass)rndm.Next(0, 3)));
                // Add random enemies to the list
            }
            
            Debug.Assert(enemies.Count == 3, "Expected 3 enemies, count is incorrect.");
            return enemies;
        }
        public void Enemies()
        {
            if (Item.skipBattle)
            {
                Console.WriteLine("\nYou used the Invisibility Cloak and skipped the enemies!");
                Item.skipBattle = false;
                return; 
            }
            List<Enemy> enemies = GenerateEnemies();
            Console.WriteLine("\nOh no! You stumbled upon 3 enemies!");

            foreach (var x in enemies)
            {
                Console.WriteLine($"{x.Name} -- {x.Health} HP -- {x.Damage} DMG");
            }
            
            Debug.Assert(enemies.Count > 0, "Enemy list is empty, shouldn't happen.");


            if (player.inventoryItem != null)
            {
                if (player.inventoryItem.Name == "Elimination Spell")
                {
                    Console.WriteLine("\nAll enemies are eliminated! You used Elimination Spell!");
                    return;
                }
                else if (player.inventoryItem.Name == "Invisibility Cloak")
                {
                    Console.WriteLine("You skipped all enemies without getting damage! You used Invisibility Cloak!");
                    return;
                }
                
            }
            while (player.GetHealth() > 0 && enemies.Any(e => e.Alive()))
            {
                Console.WriteLine("\nAttack: a" +
                                  "\nHide: h");
                string input = Console.ReadLine();
                if (input == "h")
                {
                    Console.WriteLine("You tried to hide, but you couldn't. You lost 15HP");
                    player.SetHealth(player.GetHealth() - 15);
                    
                    Debug.Assert(player.GetHealth() >= 0, "Player health is negative!");

                    if (player.GetHealth() <= 0)
                    {
                        Console.WriteLine("\nYou have been defeated by enemies :(");
                        Console.WriteLine("\nUnfortunately you lost the game!");
                        RestartGame();  // Exit 
                        return;
                    }
                    return;
                }
                else if (input == "a")
                {
                    PlayerAttacks(enemies);

                    if (enemies.Any(e => e.Alive()))
                    {
                        EnemyAttacks(enemies);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            if (player.GetHealth() > 0 && !enemies.Any(e => e.Alive()))
            {
                Console.WriteLine("\nYou have defeated all enemies. :)");
            }
            else
            {
                Console.WriteLine("\nYou have been defeated by enemies :(");
                Console.WriteLine("\nUnfortunately you lost the game!");
                RestartGame();
            }
        }

        private void EnemyAttacks(List<Enemy> enemies)
        {
            foreach (var x in enemies)
            {
                if (x.Alive())
                {
                    player.SetHealth((player.GetHealth() - x.Damage));
                    Console.WriteLine($"{x.Name} attacks you with {x.Damage}\n" +
                                      $"You have {player.GetHealth()} HP left.");
                    
                    Debug.Assert(player.GetHealth() >= 0, "Player health is negative after enemy attack!");

                }
            }
        }

        private void PlayerAttacks(List<Enemy> enemies)
        {
            Random rndm = new Random();
            int defaultDamage = 10;
            int finalDamage = defaultDamage;
            
            // 37 % chance for critical hit
            if (rndm.Next(100) < 37)
            {
                finalDamage = 25;
                Console.WriteLine($"\nCritical hit! {finalDamage} damage");
            }

            if (player.inventoryItem != null && player.inventoryItem.Type == ItemType.Weapon)
            {
                switch (player.inventoryItem.Rarity)
                {
                    case Rarity.Common:
                        finalDamage += 5;
                        break;
                    case Rarity.Rare:
                        finalDamage += 10;
                        break;
                    case Rarity.Legendary:
                        finalDamage += 30;
                        break;
                }
                Console.WriteLine($"Your weapon increased your damage to {finalDamage}.");

            }

            foreach (var enemy in enemies.Where(e => e.Alive()))
            {
                enemy.TakeDamage(finalDamage);
                Console.WriteLine($"You hit {enemy.Name} with {finalDamage} damage.\n" +
                                  $"{enemy.Name} has {enemy.Health} HP left.");
            }
                
        }
        
        
        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Anonymous", 100);
            currentRoom = new Room("You're in a dark room with some dim light coming from torch.");
            createItems();
            
            Debug.Assert(player.GetHealth() == 100, "Player health is not 100!");
            Debug.Assert(currentRoom != null, "Room was not created!");


        }

        private void createItems()
        {
            possibleItems = new List<Item>
            {
                new Item("Healing Spell", ItemType.HealSpell, Rarity.Common),
                new Item("Invisibility Cloak", ItemType.IgnoranceSpell, Rarity.Rare),
                new Item("Elimination Spell", ItemType.EliminationSpell, Rarity.Rare),
                new Item("Knife", ItemType.Weapon, Rarity.Rare),
                new Item("Metal Axe", ItemType.Weapon, Rarity.Legendary)
            };
            
            Debug.Assert(possibleItems.Count > 0, "List items is empty!");

        }

        private Item GetRandomItem()
        {
            Random rndm = new Random();
            int chance = rndm.Next(1, 101);

            List<Item> filteredItems;
            
            if (chance <= 57) // 57 % chance for common
            {
                filteredItems = possibleItems.FindAll(x => x.Rarity == Rarity.Common);
            }
            else if (chance <= 89) // 32 % chance for rare
            {
                filteredItems = possibleItems.FindAll(x => x.Rarity == Rarity.Rare);
            }
            else // 11 % chance for legendary
            {
                filteredItems = possibleItems.FindAll(x => x.Rarity == Rarity.Legendary);
            }
            
            Debug.Assert(filteredItems.Count > 0, "No valid items with rarity.!");


            return filteredItems[rndm.Next(filteredItems.Count)];
        }
        
        public void Start()
        {
            Test.RunTests();
            
            // Display the starting information to the player
            Console.WriteLine($"\nWelcome to the beginning of your adventure, {player.Name}!\n\n" +
                              $"You have {player.GetHealth()} HP.\n" +
                              $"You inventory: {player.InventoryContents()}\n" +
                              $"{currentRoom.GetDescription()}\n");
            
            bool playing = true;
            while (playing) 
            {
                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine("Unfortunately you died. The game is over.");
                    RestartGame();
                }
                
                Debug.Assert(player.GetHealth() >= 0, "Player has no health when making a choice!");

                // Display available options.
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("View room description: a");
                Console.WriteLine("View stats (health and inventory): b");
                Console.WriteLine("Pick up a random item: c");
                Console.WriteLine("Use an item: d");
                Console.WriteLine("Go to the next room: e");
                Console.WriteLine("Exit game: f");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine("\nRoom Description: " + currentRoom.GetDescription());
                        break;
                    case "b":
                        Console.WriteLine("\nCurrent stats:");
                        Console.WriteLine($"Health: {player.GetHealth()} HP");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;
                    case "c":
                        if (!player.FirstRoom && !player.PickedUpItem)
                        {
                            Item newItem = GetRandomItem();
                            player.PickUpItem(newItem);
                            player.PickedUpItem = true;
                        }
                        else if (!player.PickedUpItem)
                        {
                            Console.WriteLine("You can only pick up one item in each room");
                        }
                        else
                        {
                            Console.WriteLine("You must defeat enemies to pick up an item.");
                        }
                        break;
                    case "d":
                        player.UseItem();
                        break;
                    case "e":
                        player.NextRoom();
                        currentRoom = Room.GetNewRoom(currentRoom);
                        player.PickedUpItem = false;
                        Console.WriteLine("\nYou went to the next room...");
                        Console.WriteLine("Room Description: " + currentRoom.GetDescription());

                        GenerateEnemies(); // New battle in a new room 
                        Enemies();
                        break;
                    case "f":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid choice.");
                        break;
                }
                System.Threading.Thread.Sleep(500);

            }
        }
    }
}