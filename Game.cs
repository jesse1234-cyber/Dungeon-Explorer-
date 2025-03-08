using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;
        private bool _playing;

        public Game()
        {
            // Prompt for player name
            string playerName;
            do
            {
                Console.Write("Enter player name (max 10 characters): ");
                playerName = Console.ReadLine();
            } while (string.IsNullOrEmpty(playerName) || playerName.Length > 10);

            // Initialize the game with one room and one player
            _player = new Player(playerName, 100);
            _currentRoom = new Room("A dark cellar.", new List<string> { "Rusty Knife", "Old Key", "Torch", "Torch" });
            _playing = true;
        }

        public void Start()
        {
            while (_playing)
            {
                Console.WriteLine($"Player: {_player.Name}, Health: {_player.Health}");
                Console.WriteLine("Commands: look, pickup, inventory, quit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "look":
                        Console.WriteLine(_currentRoom.GetDescription());
                        break;
                    case "pickup":
                        string item = _currentRoom.GetRandomItem();
                        if (item != null)
                        {
                            _player.PickUpItem(item);
                        }
                        else
                        {
                            Console.WriteLine("There's nothing to pick up.");
                        }
                        break;
                    case "inventory":
                        Console.WriteLine(_player.InventoryContents());
                        break;
                    case "quit":
                        _playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}