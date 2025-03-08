using System;
using System.Media;

namespace DungeonExplorer
{
    class NewPlayer
    {
        private static Player player;
        public static void InputName(string[] args)
        {
           Console.WriteLine("Please enter the player's name: ");
           string playerName = Console.ReadLine(); 
           player = new Player(playerName, 100);
        }
    }
  

    internal class Game
    {   
        private Room currentRoom; // Aim for four rooms, game can be simple and easy

        public Game() // Constructor 
        {
            // Initialize the game with one room and one player (making them as objects?)/Welcome message
            

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
                //Print 
            }
        }
    }
}