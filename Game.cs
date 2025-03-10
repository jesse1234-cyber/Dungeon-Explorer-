using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Game class handles the main gameplay logic.
    /// Manages the player, current room, and game loop.
    /// </summary>
    internal class Game
    {
        private Player _player; // Represents the player in the game
        private Room _currentRoom; // Represents the current room the player is in
        private int _roomNumber; // Tracks the current room number
        private bool _playing; // Tracks whether the game is active

        /// <summary>
        /// Initializes the game with a player and starting room.
        /// Prompts the player for their name and sets up the first room.
        /// </summary>
        public Game()
        {
            // Prompt the user for their name
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            // If the player doesn't enter a name, default to "Hero"
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Hero";
            }

            // Create the player object with a name and initial health of 100
            _player = new Player(playerName, 100);

            // Set the initial room number and create the starting room
            _roomNumber = 0;
            _currentRoom = new Room(_roomNumber);
        }

        /// <summary>
        /// Begins the game loop where the player interacts with rooms.
        /// This loop continues until the player chooses to quit.
        /// </summary>
        public void Start()
        {
            _playing = true; // Set the game as active

            // Welcome message to the player
            Console.WriteLine($"Welcome, {_player.Name}! Your adventure begins!");

            // Start the game loop, which will continue while the player is playing
            while (_playing)
            {
                // Display current room details and allow interaction with the room
                Console.WriteLine("\n--- Room Details ---");
                _currentRoom.DescribeAndInteract(_player);

                // Show player's current health and inventory
                Console.WriteLine($"Your health: {_player.Health}");
                Console.WriteLine($"Your inventory: {_player.InventoryContents()}");

                // Ask the player what action they want to take
                Console.WriteLine("What would you like to do? (move/quit)");
                string choice = GetValidatedInput(new List<string> { "move", "quit" });

                // Process player's choice
                if (choice == "move")
                {
                    // Move to the next room by increasing the room number
                    _roomNumber++;
                    _currentRoom = new Room(_roomNumber);
                }
                else
                {
                    // If the player chooses to quit, end the game loop
                    Console.WriteLine("Thanks for playing!");
                    _playing = false;
                }
            }
        }

        /// <summary>
        /// Validates user input to ensure it matches a list of valid inputs.
        /// Repeatedly prompts the user until a valid input is given.
        /// </summary>
        /// <param name="validInputs">A list of acceptable input strings (e.g., "move", "quit")</param>
        /// <returns>The validated user input</returns>
        private string GetValidatedInput(List<string> validInputs)
        {
            string input;
            do
            {
                // Read the input from the user and convert it to lowercase
                input = Console.ReadLine()?.ToLower();
            } while (!validInputs.Contains(input)); // Keep asking until the input is valid
            return input; // Return the valid input
        }
    }
}
