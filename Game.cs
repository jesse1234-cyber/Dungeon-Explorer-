using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;
        public bool playing;
        public bool getUserInput;
        public string userInput;
        public string playerName;

        public Game()
        {
             // explain how the game works to user 
            Console.WriteLine("this is a dungeon explorer game where you progress through rooms and gather equipment");
            Console.WriteLine("you may use \"inventory\" to check what items you have aquired\nand \"health\" to see your remaining health\n");

            Console.WriteLine("you can also use \"quit\" at any time to end the game");
            Console.WriteLine("press anywhere to start the game...");
             // wait for user input to start the game
            Console.ReadKey(); 
             // clear the console to start the game fresh
            Console.Clear();

             // display game lore
            Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought\nYou can barely remember your name: ");

             // begin user input loop to get player name
            bool getUserInput = true;
            while (getUserInput) 
                {
                    userInput = Console.ReadLine();

                    if (CheckUserInput(userInput, 0)) 
                    {
                        getUserInput = false;
                        continue;
                    }
                    Console.WriteLine("please enter a valid name");
                }

             // update player name 
            playerName = userInput;

             // instantiate player and room objects
            _player = new Player(playerName, 100);
            _currentRoom = new Room();
        }
        public void Start()
        {
             // Change the playing logic into true and populate the while loop
            playing = true;
            while (playing)
            {
                 // display room description to user
                _currentRoom.GetDescription();

                 // check if player has reached end of the game
                if (_currentRoom.roomNumber == 10) 
                {
                    Console.WriteLine($"\nyou have reached a dead end, it seems this is the end of your jouney {_player.Name}...");
                    playing = false;
                    continue;
                }

                 // begin user input loop to get game choices
                getUserInput = true;
                while (getUserInput) 
                {
                    Console.WriteLine("Would you like to explore the room? (Y/N)");
                    userInput = Console.ReadLine();

                     // check if user input is valid
                    if (CheckUserInput(userInput, 1))
                    {
                        getUserInput = false; // exit loop
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\nPlease provide a valid input");
                    }
                }

                 // check if the room will have an item
                _currentRoom.GetItemRoom();

                if (userInput == "y" && _currentRoom.itemRoom)
                {
                     // select random item in room
                    _currentRoom.GetItem();

                     // begin user input loop to get game choices
                    getUserInput = true;
                    while (getUserInput)
                    {
                        Console.WriteLine($"after a thorough search you discover a {_currentRoom.item}!");
                        Console.WriteLine("Would you like to keep it? (Y/N)");
                        userInput = Console.ReadLine();

                        // check if user input is valid
                        if (CheckUserInput(userInput, 1))
                        {
                            _player.PickUpItem(_currentRoom.item);
                            getUserInput = false;
                            Console.Clear();
                        }
                        else 
                        {
                            Console.WriteLine("\nPlease provide a valid input");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("you find nothing useful in this room and continue on\n");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public bool CheckUserInput(string userInput, int inputContext) 
        {
             // check if user has input a different command before checking validity
            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                Environment.Exit(0); // exit the program
            }
            if (userInput.ToLower() == "inventory" || userInput.ToLower() ==  "i")
            {
                _player.InventoryContents(); // display player inventory
            }
            if (userInput.ToLower() == "health" || userInput.ToLower() == "h")
            {
                _player.PlayerHealth(); // display player health
            }

            if (inputContext == 0) { // name context
                if (userInput == "" || userInput == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            if (inputContext == 1) { // yes/no context
                if (userInput.ToLower() == "y" || userInput.ToLower() == "n") {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            else {
                return false;
            }

        }
    }
}