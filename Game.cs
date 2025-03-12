﻿using System;

namespace DungeonExplorer
{
    class Game
    {
        private Player _player;
        private static bool _playing = true;
        
        /// <summary>
        /// Starts the Game Flow
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to the Dungeon Game.");
            string playerName = ReadInput("Please enter your name");
            _player = new Player(playerName);
            Console.WriteLine($"Thanks, {playerName}.");
            Console.WriteLine();
            
            while (_playing)
                ProcessCommand();
        }

        /// <summary>
        /// Prompts & Processes command entered by the player
        /// </summary>
        private void ProcessCommand()
        {
            bool processed = true;

            do
            {
                string commandName = ReadInput("Enter a command, or type 'help' for a list of commands");
                switch (commandName.Trim().ToLower())
                {
                    case "next":
                        NextRoom();
                        break;
                    case "use":
                        UseItem();
                        break;
                    case "inventory":
                        DisplayInventory();
                        break;
                    case "health":
                        DisplayHealth();
                        break;

                    case "help":
                        Help();
                        break;
                    case "quit":
                        Quit();
                        break;
                    default:
                        processed = false;
                        Console.WriteLine($"'{commandName}' is not a valid command.");
                        break;
                }
            } while (!processed);
            
            Console.WriteLine();
        }

        /// <summary>
        /// Moves player to the next room. Rooms are linear and they can only progress to new rooms.
        /// </summary>
        public void NextRoom()
        {
            Room room = new Room(_player);
            
            if (room.Monster != null)
            {
                Console.WriteLine($"You just ran into a {room.Monster}!");
                Monster.AttackPlayer(_player, (MonsterType)room.Monster);
                Console.WriteLine();
            } else if (room.Item != null)
            {
                _player.PickUpItem((ItemType)room.Item);
                Console.WriteLine($"You picked up a {room.Item}. Use the 'use' command to use this item.");
            } else
                Console.WriteLine("Nothing was discovered in this room.");
            
            _player.HasBadLuck = false;
        }
        
        /// <summary>
        /// Use item if that item exists in the player's inventory. Multiple choice dialogue is triggered to select an item type.
        /// </summary>
        private void UseItem()
        {
            string[] itemTypes = Enum.GetNames(typeof(ItemType));
            ItemType itemChoice = (ItemType)ReadMultiChoiceInt("Please choose an item to use", itemTypes);
            
            if (!_player.HasItem(itemChoice))
            {
                Console.WriteLine($"You do not have a {itemChoice} in your inventory.");
                return;
            }
            
            _player.UseItem(itemChoice);
        }

        /// <summary>
        /// Displays all items in the player's inventory as well as the number of items in there.s
        /// </summary>
        private void DisplayInventory()
        {
            Console.WriteLine($"Inventory: {_player.InventoryContents()}");
        }
        
        /// <summary>
        /// Displays player's health
        /// </summary>
        private void DisplayHealth()
        {
            Console.WriteLine($"Health: {_player.Health}%");
        }

        /// <summary>
        /// Displays list of commands
        /// </summary>
        private void Help()
        {
            Console.WriteLine(@"
Game:
    next: Moves player to the next room
    use: Use health potion if player has one in their inventory
    inventory: Displays items in inventory
    health: Gets player's health

Utility:
    help: A list of all available commands
    quit: quits the game
");
        }

        /// <summary>
        /// Reads text input from the player. Repeats prompt until non-empty string is entered.
        /// </summary>
        /// <param name="message">Message that is displayed when player is prompted.</param>
        /// <returns>Input entered by player.</returns>
        private string ReadInput(string message)
        {
            string input = null;

            while (String.IsNullOrEmpty(input))
            {
                Console.Write($"{message}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Prompts multiple choice input based on array provided.
        /// </summary>
        /// <param name="message">Message that displays when prompting player for choice input</param>
        /// <param name="choices">List of choices that are displayed numerically with respective strings</param>
        /// <returns>Returns index of array player chose</returns>
        private int ReadMultiChoiceInt(String message, string[] choices)
        {
            string choiceDisplay = "";
            for (var i = 0; i < choices.Length; i++)
            {
                string choice = choices[i];
                choiceDisplay += $"{i + 1}: {choice}\n";
            }

            int numberChoice = -1;
            while (true)
            {
                Console.WriteLine(choiceDisplay);
                Console.Write($"{message}: ");
                
                string inputRaw = Console.ReadLine();
                if (Int32.TryParse(inputRaw, out numberChoice))
                {
                    if (numberChoice > choices.Length)
                    {
                        Console.WriteLine("That is not a valid choice.");
                        continue;
                    } 
                    
                    break;
                }
                
                Console.WriteLine("Please enter a valid number");
            }

            return numberChoice - 1;
        }
        
        /// <summary>
        /// Quits the game and waits for keyboard input to exit process
        /// </summary>
        public static void Quit()
        {
            _playing = false;
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}