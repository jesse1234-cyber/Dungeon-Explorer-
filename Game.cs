using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Random random;
        private List<Room> rooms;
        private List<string> items;
        private List<string> charNames;

        public Game()
        {
            random = new Random();

            charNames = new List<string>
            {
                "John", "Jake", "Mathew", "Dan", "Mike", "Blake", "Morgan", "Sebastian"
            };

            string playerName;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("========================================");
                    Console.WriteLine("           DUNGEON EXPLORER ");
                    Console.WriteLine("========================================\n");
                    Console.ResetColor();
                    Console.WriteLine("Do you wish to name your character? (Yes|No)");
                    string input = Console.ReadLine()?.Trim().ToLower();

                    if (input == "yes")
                    {
                        Console.WriteLine("Please name your character:");
                        playerName = Console.ReadLine();
                        break;
                    }
                    else if (input == "no")
                    {
                        playerName = charNames[random.Next(charNames.Count)];
                        Console.WriteLine($"Your character's name is {playerName}.");
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid input! Please enter 'Yes' or 'No'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            player = new Player(playerName, 100);

            items = new List<string> { "Health Potion", "Gas Mask", "Rusty Sword", "Broken Shield", "A pile of bones", "Gold Bar" };

            rooms = new List<Room>
            {
                new Room("\nDust chokes the air, and old cobwebs stretch across the walls. A faint creak echoes as if the hall itself is alive.", items[random.Next(items.Count)]),
                new Room("\nThe floor is cracked, and streams of lava flow in the cracks, casting an eerie red glow. The heat is oppressive.", items[random.Next(items.Count)]),
                new Room("\nBioluminescent flowers bathe the room in an eerie glow, their sweet scent masking the strange whispers in the air.", items[random.Next(items.Count)]),
                new Room("\nTwisting, narrow corridors stretch in every direction, and the air grows colder the deeper you venture.", items[random.Next(items.Count)]),
                new Room("\nA vast, black pit yawns before you, with strange sounds rising from its depths, as though something is waiting.", items[random.Next(items.Count)])
            };

            currentRoom = rooms[random.Next(rooms.Count)];
        }

        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player: {player.Name}, Health: {player.Health}");
                Console.ResetColor();
                Console.WriteLine("\nInventory: " + player.InventoryContents());
                Console.WriteLine($"\nCurrent Room: {currentRoom.GetDescription()}");
                Console.WriteLine($"\nThere is a {currentRoom.Item} in this room.");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Do you want to pick this item up? (Yes|No)");
                        string input = Console.ReadLine()?.Trim().ToLower();

                        if (input == "yes")
                        {
                            player.PickUpItem(currentRoom.Item);
                            Console.WriteLine($"\nYou picked up {currentRoom.Item}.");
                            break;
                        }
                        else if (input == "no")
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Invalid input! Please enter 'Yes' or 'No'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nDo you want to continue? (Yes|No)");
                        string continueInput = Console.ReadLine()?.Trim().ToLower();

                        if (continueInput == "no")
                        {
                            playing = false;
                            Console.WriteLine("Game ended.");
                            return;
                        }
                        else if (continueInput == "yes")
                        {
                            Room newRoom;
                            do
                            {
                                newRoom = rooms[random.Next(rooms.Count)];
                            } while (newRoom == currentRoom);

                            currentRoom = newRoom;
                            Console.WriteLine("\n========================================\nYou have moved to the next room...");
                            break;
                        }
                        else
                        {
                            throw new Exception("Invalid input! Please enter 'Yes' or 'No'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
