using System;

namespace DungeonExplorer
{
    class Game
    {
        private Player _player;
        private static bool _playing = true;
        
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

        private void DisplayInventory()
        {
            Console.WriteLine($"Inventory: {_player.InventoryContents()}");
        }
        
        private void DisplayHealth()
        {
            Console.WriteLine($"Health: {_player.Health}%");
        }

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
        
        public static void Quit()
        {
            _playing = false;
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}