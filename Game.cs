using System;
using System.Media;
using System.Text;

namespace DungeonExplorer
{
    class Game
    {
        private Player _player;
        
        public void Start()
        {
            Console.WriteLine("Welcome to the Dungeon Game.");
            string playerName = ReadInput("Please enter your name");
            _player = new Player(playerName);
            Console.WriteLine($"Thanks, {playerName}.");
            Console.WriteLine();
            
            while (true)
            {
                if (ProcessCommand())
                    break;
            }
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private bool ProcessCommand()
        {
            var processed = true;

            do
            {
                string commandName = ReadInput("Enter a command, or type 'help' for a list of commands");
                switch (commandName.Trim().ToLower())
                {
                    case "next":
                        break;
                    case "use":
                        break;

                    case "help":
                        Help();
                        break;
                    case "quit":
                        return true;

                    default:
                        processed = false;
                        Console.WriteLine($"'{commandName}' is not a valid command.");
                        break;
                }
            } while (!processed);
            
            Console.WriteLine();
            return false;
        }

        public void NextRoom()
        {
            
        }
        
        public void UseItem()
        {
            
        }

        private void Help()
        {
            Console.WriteLine(@"
Game:
    next: Moves player to the next room
    use: Opens dialogue to use an item inside your inventory

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
    }
}