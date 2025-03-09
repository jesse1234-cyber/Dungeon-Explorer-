using System;
using System.Media;

namespace DungeonExplorer
{
    class NewPlayer // New class to allow for player to enter their own name
    {
        private static Player player;
        public static void InputName(string[] args)
        {
           Console.WriteLine("Please enter the player's name: ");
           string playerName = Console.ReadLine(); 
           player = new Player(playerName, 100); // Setting and initialising Player name and health
        }
    }

    internal class Game
    {   
        private Room currentRoom; // Class attribute (within the class Game) Aim for four rooms, game can be simple and easy

        public string startMessage; // attribute for Game()

        public Game() // Constructor 
        {
            // Initialize the game with one room and one player (making them as objects?)/Welcome message
            startMessage = "Welcome to Dungeon Explorer! You find yourself in a strange room.";
        }
        
        // Try execept for erroneous input (within "Start" method)
        // Should there be a new method for a main gameplay loop?- and just have Start() as intialisation of a Room- or would the code base be too small?
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true; // Changed to true (away from example). Return to false to end program? (condition; if false, "break")
            while (playing) // assumes playing is true for this to execute
            {
                // !Code your playing logic here
                Game currentPlay = new Game(); // currentPlay = object of Game, representative of a current playthrough when the program runs
                Console.WriteLine(currentPlay.startMessage);
            }
        }
    }
}