using System;
using System.Collections.Generic;


namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public Room room = new Room();
        // bool playing = false;

        public Game()
        {
            var playerName = Player.GetPlayerName();
            // var playerInventory = Player.InventoryContents();
            // validate player name

            player = new Player(playerName, 100);
            Start();
        }
        public void Start()
        {
            Console.WriteLine($"\nYour chosen name is now: {Player.Name}");
            Console.WriteLine("You have " + Player.Health + " health points.");
            Console.WriteLine("You can move to the next room and make desicions when prompted\n");

            Program.ClearConsole();

            Console.WriteLine("You, " +Player.Name+ " begin your adventure facing down an a dark open mineshaft. A cool breeze washes over you as you try to peer into the darkness. It was a exhausting 3 day hike here and your not turning back now. You take a deep breath and step into the darkness.");
            Console.WriteLine("Press any key to continue...\n");

            Console.ReadKey();
            bool playing = true;
            // Console.WriteLine("playing = true");

            Program.ClearConsole();

            MoveToNextRoom();

            void MoveToNextRoom()
            {
                string roomDescription = room.GetDescription();
                PlayerInput();
            }


            void PlayerInput()
            {
                Console.WriteLine("What do you wish to do?.");
                Console.WriteLine(Player.Health + " health points.");
                Console.WriteLine("Press Q for control scheme");

                Console.WriteLine("");

                var playerKey = Console.ReadKey().Key;

                Program.ClearConsole();

                if (playerKey == ConsoleKey.C)
                {
                    // Check the room for items
                    List<string> roomItems = room.GetItems();

                    Console.WriteLine(string.Join(", ", roomItems));
                    Console.WriteLine("Input the item you wish to interact with...");

                    var inputItem = Console.ReadLine();

                    if (roomItems.Contains(inputItem.ToLower()))
                    {
                        Console.WriteLine($"You have picked up {inputItem}");
                        player.PickUpItem(inputItem);
                    }

                    PlayerInput();

                }
                else if (playerKey == ConsoleKey.I)
                {
                    // Write the player's inventory
                    Player.InventoryContents();

                    // Console.WriteLine(player.InventoryContents());
                    PlayerInput();
                }
                else if (playerKey == ConsoleKey.F)
                {
                    // Move to the next room
                    Console.WriteLine("You move to the next room");
                    room.GetDescription();
                    PlayerInput();
                    //currentRoom = 2;
                }

                else if (playerKey == ConsoleKey.Q)
                {

                    Console.WriteLine("Press (C) to check the room for items");
                    Console.WriteLine("Press (I) to check your inventory");
                    Console.WriteLine("Press (F) to move to the next room");
                    PlayerInput();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    PlayerInput();
                }
            }





            // Change the playing logic into true and populate the while loop
            while (playing)
            {
                //var InventoryCheck = player.InventoryContents();
                //if (Console.ReadKey().Key == ConsoleKey.I) 
                //{ 
                //    Console.WriteLine("You check your inventory...");
                //    Console.WriteLine("");
                //    Console.WriteLine(InventoryCheck);
                //}

                //else if (Console.ReadKey().Key == ConsoleKey.Q)
                //{
                //    Console.WriteLine("Press (C) to check the room for items");
                //    Console.WriteLine("Press (I) to check your inventory");
                //    Console.WriteLine("Press (F) to move to the next room");
                //    Console.WriteLine("Press (S) to move to the other next room");
                //}
            }
        }
    }
}