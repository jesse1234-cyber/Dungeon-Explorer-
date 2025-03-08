using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Player", 100);
            currentRoom = new Room("A dark cellar.", "Rusty Knife");
            playing = true;
        }

        public void Start()
        {
            while (playing)
            {
                Console.WriteLine($"Player: {player.Name}, Health: {player.Health}");
                Console.WriteLine("Commands: look, pickup, quit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "look":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "pickup":
                        player.PickUpItem(currentRoom.Item);
                        break;
                    case "quit":
                        playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}