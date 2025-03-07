using System;
using System.Collections.Generic;
using System.Media;
using System.Net.Mime;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Item> possibleItems;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Anonymous", 100);
            currentRoom = new Room("You're in a dark room with some dim light coming from torch.");
            createItems();
        }

        private void createItems()
        {
            possibleItems = new List<Item>
            {
                new Item("Healing Spell", ItemType.HealSpell, Rarity.Common),
                new Item("Invisibility Cloack", ItemType.IgnoranceSpell, Rarity.Rare),
                new Item("Elimination Spell", ItemType.EliminationSpell, Rarity.Rare),
                new Item("Knife", ItemType.Weapon, Rarity.Rare),
                new Item("Metal Axe", ItemType.Weapon, Rarity.Legendary)
            };
        }

        private Item GetRandomItem()
        {
            Random rndm = new Random();
            int chance = rndm.Next(1, 101);

            if (chance <= 74) // 74 % chance for common
            {
                return possibleItems.Find(x => x.Rarity == Rarity.Common);
            }
            else if (chance <= 99) // 25 % chance for rare
            {
                return possibleItems.Find(x => x.Rarity == Rarity.Rare);
            }
            else // 1 % chance for legendary
            {
                return possibleItems.Find(x => x.Rarity == Rarity.Legendary);
            }

        }
        
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            
            // Display the starting information to the player
            Console.WriteLine($"\nWelcome to the beginning of your adventure, {player.Name}!\n\n" +
                              $"You have {player.GetHealth()} HP.\n" +
                              $"You inventory: {player.InventoryContents()}\n" +
                              $"{currentRoom.GetDescription()}\n");
            
            bool playing = true;
            while (playing) 
            {
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
                        Item newItem = GetRandomItem();
                        player.PickUpItem(newItem);
                        break;
                    case "d":
                        player.UseItem();
                        break;
                    case "e":
                        player.NextRoom();
                        currentRoom = Room.GetNewRoom(currentRoom);
                        Console.WriteLine("\nYou went to the next room...");
                        Console.WriteLine("Room Description: " + currentRoom.GetDescription());
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