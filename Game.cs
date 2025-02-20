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
            // Initialize the game with one room and one player

            player = new Player("Mitchell", 100);
            currentRoom = new Room("Dungeon Entrance \nAn eary aura roams through the path in front of you with you being able to sense the danger up ahead.");
            Console.WriteLine($"Player Name: {player.Name} \tPlayer Health: {player.Health} \nStarting Room: {currentRoom.GetDescription()} ");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;

            Player player = new Player("Mitchell", 100);
            Console.WriteLine($"Player Name: {player.Name} \nPlayer Health: {player.Health}");

            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine("Hung on opposite walls are a sword and a bow with a quiver.\nDo you choose the bow or the sword? (You can only pick one.)");
                string weaponChoice = Console.ReadLine();
                if (weaponChoice == "Bow")
                {
                    Console.WriteLine($"{player.Name} has chosen the bow");
                }
                else if (weaponChoice == "Sword")
                {
                    Console.WriteLine($"{player.Name} has chosen the sword.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. User can choose only the sword or the bow.");
                    playing = false;
                }

            }
            Console.WriteLine("Game is starting...");

            Console.ReadLine();
            playing = false;
        }
    }
}
