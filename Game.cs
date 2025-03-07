using System;
using System.Media;
using System.Text;
using System.Transactions;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            _currentRoom = new Room("Cell");

            Console.WriteLine(_currentRoom.GetDescription());
        }
        public void Start()
        {
            Console.Write("Welcome to Dungeon Explorer!\nPlease enter your name: ");
            string playerName = Console.ReadLine();

            _player = new Player(playerName, 100);

            foreach(var item in _currentRoom.GetItems())
            {
                _player.PickUpItem(item);
                Console.WriteLine($"\nYou have picked up a {item}.");
            }

            Note();

            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nPlease choose an option:" +
                "\n1. View the room's description" +
                "\n2. View your health" +
                "\n3. View your inventory" +
                "\n4. Continue playing");
                Console.Write("Enter '1', '2', '3' or '4': ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("\n" + _currentRoom.GetDescription());
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nHealth: " + _player.Health);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\nInventory: " + _player.InventoryContents());
                }
                else if (choice == "4")
                {
                    Console.WriteLine("\nYou have chosen to continue playing.");
                    playing = false;
                }
            }
        }

        private void Note()
        {
            Console.WriteLine($"\nWith your torch, you notice that there's a note on the floor. It reads...\n" + 
            $"\nDear {_player.Name},\n\nYou have been locked inside the dungeon. You must navigate through the rooms to escape." +
            "\nBeware, you will need to battle creatures throughout your journey!");
        }
    }
}
