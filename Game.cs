using System;
using System.Collections.Generic;
using DungeonExplorer;

namespace DungeonExplorer
{
    internal class Game
    {   
        private Player player; // Player character
        private Room currentRoom; // The current room that the player is in
        private Random random; // Random number generator
        private List<Room> rooms; // A list with all the different available rooms that are in them
        private List<string> items; // A list of all the different available items

        public Game()
        {   
            // Intializes the player with a name and provides a default amount of health being 100
            player = new Player("Jakub", 100);
            random = new Random();
            // List of all the items that can be randomly chosen from
            items = new List<string> { "Health Potion", "Gas Mask", "Rusty Sword", "Broken Shield", "A pile of bones", "Gold Bar"};
            // List of all the rooms that can be randomly picked from, with a description with a random item generating everytime it is chosen
            rooms = new List<Room>
            {
                new Room("\nDust chokes the air, and old cobwebs stretch across the walls. A faint creak echoes as if the hall itself is alive.", items[random.Next(items.Count)]),
                new Room("\nThe floor is cracked, and streams of lava flow in the cracks, casting an eerie red glow. The heat is oppressive.", items[random.Next(items.Count)]),
                new Room("\nBioluminescent flowers bathe the room in an eerie glow, their sweet scent masking the strange whispers in the air.", items[random.Next(items.Count)]),
                new Room("\nTwisting, narrow corridors stretch in every direction, and the air grows colder the deeper you venture.", items[random.Next(items.Count)]),
                new Room("\nA vast, black pit yawns before you, with strange sounds rising from its depths, as though something is waiting.", items[random.Next(items.Count)])
            };
            // Updates the currentRoom variable with a random room from the list as the starting room
            currentRoom = rooms[random.Next(rooms.Count)];
        }

        public void Start()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========================================");
            Console.WriteLine("           DUNGEON EXPLORER ");
            Console.WriteLine("========================================\n");
            Console.ResetColor();

            bool playing = true; // Game loop, if false game stops
            while (playing)
            {  
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player: {player.Name}, Health: {player.Health}"); // Displays the player name and player health
                Console.ResetColor();
                Console.WriteLine("\nInventory: " + player.InventoryContents()); // Displays the contents of the players inventory
                Console.WriteLine($"\nCurrent Room: {currentRoom.GetDescription()}"); // Displays the current room and its description
                Console.WriteLine($"\nThere is a {currentRoom.Item} in this room."); // Displays what item is in the current room
                Console.WriteLine("Do you want to pick this item up? (Yes|No)"); // Displays whether the user wants to pick up the item that is in the room or not
                string input = Console.ReadLine(); // Reads the input from the previous line

                // If the input from the user is yes, it picks up the item and displays that it has been picked up

                if (input.ToLower() == "yes")
                {
                    player.PickUpItem(currentRoom.Item);
                    Console.WriteLine($"\nYou picked up {currentRoom.Item}.");
                }

                // Asks the user if they want to continue playing

                Console.WriteLine("\nDo you want to continue? (Yes|No)");
                string continueInput = Console.ReadLine();

                // If the user inputs it updates variable playing to false, which stops the loop and ends the game

                if (continueInput.ToLower() == "no")
                {
                    playing = false;
                    Console.WriteLine("Game ended.");
                }
                else
                {
                    // If input is yes creates a new random room from the list of rooms and displays that the user has moved into a new room

                    Room newRoom;
                    do
                    {
                        newRoom = rooms[random.Next(rooms.Count)];
                    } while (newRoom == currentRoom);

                    currentRoom = newRoom;
                    Console.WriteLine("\n========================================\nYou have moved to the next room...");
                }
            }
        }
    }
}
