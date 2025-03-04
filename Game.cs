using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            Console.WriteLine("Please enter your name: ");
            var playerName = Console.ReadLine();
            // validate player name

            player = new Player(playerName, 100);
            Start();
        }
        public void Start()
        {
            Console.WriteLine("Your chosen name is now: " + Player.Name);
            Console.WriteLine("You have " + Player.Health + " health points.");
            Console.WriteLine("Your can check your inventory by pressing 'I' ");
            Console.WriteLine("You can move to the next room and make desicions when prompted");



            Console.WriteLine("You, " +Player.Name+ " begin your adventure facing down an a dark open mineshaft. A cool breeze washes over you as you try to peer into the darkness. It was a exhausting 3 day hike here and your not turning back now. You take a deep breath and step into the darkness.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MoveToNextRoom();

            void MoveToNextRoom()
            {
                currentRoom = new Room();
                string CurrentRoom = Room.GetDescription();
                Console.WriteLine(CurrentRoom);
            }

            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}