using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player = new Player("Mitchell", 100);
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            //Player player = new Player("Mitchell", 100);
            //Room room = new Room("Living Room");
            Console.WriteLine($"Player Name: {player.Name} \tPlayer Health: {player.Health} \t Starting Room: ");
            //Console.WriteLine($"Starting Room: ");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;


            //Player player = new Player("Mitchell", 100);

            Console.WriteLine("Start Constructor starts here...");
            
            //Player player = new Player("Dave", 30);
            //Console.WriteLine($"Player Name: {player2.Name} \nPlayer Health: {player2.Health}");
            //Console.WriteLine($"Player Name: {player.Name} \nPlayer Health: {player.Health - 10}");
            //Console.WriteLine($"Player Name: {player.Name} \nPlayer Health: {player.Health}");
            
            while (playing)
            {
                // Code your playing logic here
                Console.ReadLine();
                playing = false;
            }
        }
    }
}