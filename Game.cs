using System;
using System.Media;
using Microsoft.Win32;

namespace DungeonExplorer
{
    internal class Game
    {
        public Player player { get; set; }
        public Room currentRoom { get; set; }

        public Game(string userName)
        {
            player = new Player(userName, 15);
            currentRoom = new Room("Kitchen.");
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Welcome " + player.Name);
                Console.WriteLine("You are in " + currentRoom.GetDescription());
            }
        }
    }
}