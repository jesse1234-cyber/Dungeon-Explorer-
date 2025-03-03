using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public bool playing;
        public string userInput;

        public Game()
        {
            Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought\nYou can barely remember your name: ");
            string PlayerName = Console.ReadLine();
            Console.WriteLine("you pull yourself to your feet and examine your surroundings");

            player = new Player(PlayerName, 100);
            currentRoom = new Room("start room :D");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop

            playing = true;
            while (playing)
            {
                // Code your playing logic here

                currentRoom.GetDescription();
                if (currentRoom.roomNumber == 0) {
                    currentRoom.roomNumber++;
                    continue;
                }
                else if (currentRoom.roomNumber == 10)
                {
                    Console.WriteLine($"\nyou have reached a dead end, it seems this is the end of your jouney {player.Name}...");
                    playing = false;
                    continue;
                }

                bool getUserInput = true;
                while (getUserInput) 
                {
                    Console.WriteLine("Would you like to explore the room? (Y/N)");
                    userInput = Console.ReadLine();

                    if (CheckUserInput(userInput, 0)) 
                    {
                        getUserInput = false;
                    }
                }
                getUserInput = true;

                currentRoom.GetItemRoom();
                if (userInput == "y" && currentRoom.itemRoom)
                {
                    currentRoom.GetItem();
                    Console.WriteLine($"after a thorough search you discover a {currentRoom.Item}!");
                    Console.WriteLine("Would you like to keep it? (Y/N)");
                    userInput = Console.ReadLine();
                    if (CheckUserInput(userInput, 0))
                    {
                        player.PickUpItem(currentRoom.Item);
                    }
                }
                else
                {
                    Console.WriteLine("you find nothing useful in this room and continue on");
                }
            }
        }

        public bool CheckUserInput(string userInput, int inputContext) 
        {
            if (userInput == "quit")
            {
                playing = false;
            }
            if (userInput == "inventory")
            {
                player.InventoryContents();
            }

            if (inputContext == 0) { // yes/no context
                if (userInput.ToLower() == "y" || userInput.ToLower() == "n") {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (inputContext == 1) { // fight/run context // need to add enemies in future update
                if (userInput.ToLower() == "f" || userInput.ToLower() == "r")
                {
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