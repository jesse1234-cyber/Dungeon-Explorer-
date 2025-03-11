using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DungeonExplorer
{
    /// <summary>
    ///  Handles the game flow and initializes the player as well as rooms.
    /// </summary>
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;
        private Room _cell;
        private Room _doom;

        /// <summary>
        /// Initializes the game with rooms and items
        /// </summary>
        public Game()
        { 
            _cell = new Room("Cell", "A dark cell with a bed.");
            _doom = new Room("Room of Doom", "A huge room with bats.");
            
            // Sets the current room to the "Cell"
            _currentRoom = _cell;

            // Adds items to rooms
            _doom.AddItem("sword") ;
        }

        public void RoomOfDoom(Room newRoom)
        {
            _currentRoom = newRoom;
            Console.WriteLine($"\nYou are now in the {newRoom.RoomName}.");  // Displays which room the player is in
            
            // Checks if the Room of Doom has a sword
            if (_currentRoom.RoomName == "Room of Doom" && _currentRoom.ContainsItem("sword"))
            {
                PickUpSword();
            }
        }

        /// <summary>
        /// Asks the user if they want to pick up a sword from the Room of Doom
        /// </summary>
        private void PickUpSword()
        {
            while(true)
            {
                // If the player already has a sword, then they will not be asked
                if (_player.InventoryContents().Contains("sword"))
                {
                    return;
                }

                // If the player does not already have a sword, they will be asked if they want a sword
                while (true)
                {
                    Console.WriteLine("\nThere is a sword in front of you." + 
                    "\nDo you want to pick up the sword? y/n ");
                    string swordChoice = Console.ReadLine().ToLower();

                    if (swordChoice.ToLower() == "y")
                    {
                        _player.PickUpItem("sword");
                        Console.WriteLine("You have picked up a sword.");
                        return;
                    }
                    else if (swordChoice.ToLower() == "n")
                    {
                        Console.WriteLine("You have chosen not to pick up the sword.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n': ");
                    }
                }
            }
        }
        /// <summary>
        /// Starts the game and handles the game flow
        /// </summary>
        public void Start()
        {
            Console.WriteLine("\nWelcome to Dungeon Explorer!");

            // Prompts user for their name
            string playerName = null;
            while (string.IsNullOrEmpty(playerName))
            {
                Console.Write("Please enter your name: ");
                playerName = Console.ReadLine();

                // Checks if name is valid (if it is null or empty)
                Debug.WriteLine("Name can't be empty.");

                // If name is empty or null, the program will prompt the user again
                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Your name cannot be empty.");
                }
            }
            // Initializes game with one player & sets health to 100
            _player = new Player(playerName, 100);  

            // Adds a torch to the player's inventory
            foreach (var item in _currentRoom.GetItems())
            {
                _player.PickUpItem(item);
                Console.WriteLine($"\nYou have picked up a {item}.");
            }

            Note();

            bool playing = true;
            while (playing)
            {
                // Prompts user to choose an option - to view room's description, health, inventory or to continue playing
                Console.WriteLine("\nPlease choose an option:" +
                "\n1. View the room's description" +
                "\n2. View your health" +
                "\n3. View your inventory" +
                "\n4. Explore" +
                "\n5. Continue playing");
                Console.Write("Enter '1', '2', '3' '4' or '5': ");
                string options = Console.ReadLine();

                if (options == "1")
                {
                    Console.WriteLine("\n" + _currentRoom.GetDescription());  // Displays the room's description
                }
                else if (options == "2")
                {
                    Console.WriteLine("\nHealth: " + _player.Health);  // Displays the player's health
                }
                else if (options == "3")
                {
                    Console.WriteLine("\nInventory: " + _player.InventoryContents());  // Display's the player's inventory
                }
                else if (options == "4")
                {
                    // Asks the player which room they would like to explore
                    Console.WriteLine("\nWhich room would you like to explore?" +
                    "\n1. Cell" +
                    "\n2. Room of Doom");
                    Console.Write("Enter '1' or '2': ");
                    string roomChoice = Console.ReadLine();
                    if (roomChoice == "1")
                    {
                        Console.WriteLine("\nYou are now in the Cell.");
                    }
                    else if (roomChoice == "2")
                    {
                        RoomOfDoom(_doom);
                    }
                    else
                    {
                        Console.WriteLine("\n Invalid choice.");
                    }
                }
                else if (options == "5")
                {
                    Console.WriteLine("\nYou have chosen to continue playing.");
                    playing = false;
                }
            }
        }

        /// <summary>
        /// Displays a note to the player near the start of the game to introduce them to the objective of the game
        /// </summary>
        private void Note()
        {
            Console.WriteLine($"\nWith your torch, you notice that there's a note on the floor. It reads...\n" + 
            $"\nDear {_player.Name},\n\nYou have been locked inside the dungeon. You must navigate through the rooms to escape." +
            "\nBeware, you will need to battle creatures throughout your journey!");
        }
    }
}
