using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Create a single room
            Room room1 = new Room("A damp, cold room with seemingly little light...");

            // Create Player
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Adventurer";
            }

            player = new Player(playerName, 100);
            player.EnterRoom(room1);

            currentRoom = room1;

            // Add an item to the room
            room1.CreateItem("Crusty Key");
        }

        public void Start()
        {
            while (player.Health > 0)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1 - View room description");
                Console.WriteLine("2 - View player stats");
                Console.WriteLine("3 - Pick up an item");
                Console.WriteLine("4 - Exit Game");

                string action = Console.ReadLine()?.Trim();

                if (action == "1")
                {
                    Console.WriteLine(player.CurrentRoom.GetDescription());
                }
                else if (action == "2")
                {
                    player.DisplayStatus();
                }
                else if (action == "3")
                {
                    if (!string.IsNullOrEmpty(player.CurrentRoom.RoomItem))
                    {
                        player.PickUpItem(player.CurrentRoom.RoomItem);
                        Console.WriteLine($"You picked up: {player.CurrentRoom.RoomItem}");
                        player.CurrentRoom.RemoveItem(); 
                    }
                    else
                    {
                        Console.WriteLine("There's nothing to pick up.");
                    }
                }
                else if (action == "4")
                {
                    Console.WriteLine("Exiting the game...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Choose between options 1-4.");
                }
            }
            Console.WriteLine("Game over.");
        }
    }
}

