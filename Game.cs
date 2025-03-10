using System;
using System.Diagnostics.Eventing.Reader;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private static Player player;
        

        public static void GameStart()                                                       // Initialize the game with one room and one player
        {
            Console.WriteLine("Welcome to the Pirate Dungeon Explorer!");            
        }

        public static void StoryOpening()
        {
            Console.WriteLine("You have entered the island by ship, instantly you notice two large caves shaped like skulls");          // Start of Story or Map
            Console.WriteLine("The left cave has a old wooden sign reading 'Beware of the giant spider'");
            Console.WriteLine("The right cave has a rusted metal sign reading 'Beware of the giant snake'");
        }

        public static string RoomChoice1()
        {
            Console.WriteLine("So .. ");                                                // Prompt user for room choice
            Console.WriteLine("Which cave would you like to enter? left or right");

            do
            {
                string roomchoice = Console.ReadLine();

                if (roomchoice == "left")                
                    return "left";                
                else if (roomchoice == "right")               
                    return "right";              
                else
                    Console.WriteLine("Invalid Input: Please enter left or right...");                  // Exception handling prompt user to type correct input

            } while (true);
            ///
        }

        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}