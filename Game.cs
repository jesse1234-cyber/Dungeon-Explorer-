using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            /*
            Initialize the game with the start room and the player

            Attributes:
            ???

            Methods:
            ???
            */

            Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought\nYou can barely remember your name: ");
            string PlayerName = Console.ReadLine();
            Console.WriteLine("you pull yourself to your feet and examine your surroundings");

            player = new Player(PlayerName, 100);
            currentRoom = new Room("start room :D");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop

            bool playing = true;
            while (playing)
            {
                // Code your playing logic here

                currentRoom.GetDescription();
                if (currentRoom.roomNumber == 0) {
                    currentRoom.roomNumber++;
                    continue;
                }
                Console.WriteLine("Would you like to explore the room? (Y/N)");
                string userInput = Console.ReadLine();
                if (CheckUserInput(userInput, 0))
                {
                    if (userInput == "y")
                    {
                        ;
                    }
                }
                //Console.WriteLine("Would you like to explore the room further?? (Y/N)");
                //Console.WriteLine("you hear a small growling");
                //Console.WriteLine("you catch a sparkle in the corner of your eye");

                /*
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine(currentRoom.GetDescription());
                }
                else
                {
                    Console.WriteLine("You are a coward");
                }
                */

                playing = false;
            }
        }

        public bool CheckUserInput(string userInput, int inputContext) 
        {
            if (inputContext == 0) {
                if (userInput.ToLower() == "y" || userInput.ToLower() == "n") {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (inputContext == 1) {
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