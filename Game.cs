using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        Room room = new Room();
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
            Console.WriteLine("");
            Console.WriteLine("Your chosen name is now: " + Player.Name);
            Console.WriteLine("You have " + Player.Health + " health points.");
            Console.WriteLine("You can move to the next room and make desicions when prompted");
            Console.WriteLine("");



            Console.WriteLine("You, " +Player.Name+ " begin your adventure facing down an a dark open mineshaft. A cool breeze washes over you as you try to peer into the darkness. It was a exhausting 3 day hike here and your not turning back now. You take a deep breath and step into the darkness.");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("");
            Console.ReadKey();
            bool playing = true;
            // Console.WriteLine("playing = true");
            MoveToNextRoom();

            void MoveToNextRoom()
            {
                Console.WriteLine("ROOM DESCRIPTION PRINTED");
                string roomDescription = room.GetDescription();
                PlayerInput();
            }


            void PlayerInput()
            {
                Console.WriteLine("What do you wish to do?.");
                Console.WriteLine("Press Q for control scheme");
                Console.WriteLine("");

                var playerKey = Console.ReadKey().Key;

                if (playerKey == ConsoleKey.C)
                {
                    // Check the room for items
                    Console.WriteLine("You check the room for items");
                    // Console.WriteLine(string.Join(", ", Room.room1Items));
                    string roomItems = room.GetItems();
                    PlayerInput();

                }
                else if (playerKey == ConsoleKey.I)
                {
                    // Check the player's inventory
                    Console.WriteLine("You check your inventory");
                    // Console.WriteLine(player.InventoryContents());
                    PlayerInput();
                }
                else if (playerKey == ConsoleKey.F)
                {
                    // Move to the next room
                    Console.WriteLine("You move to the next room");
                    room.GetDescription();
                    //currentRoom = 2;
                }
                else if (playerKey == ConsoleKey.S)
                {
                    // Move to the other next room
                    Console.WriteLine("You move to the other next room");
                }

                else if (playerKey == ConsoleKey.Q)
                {

                    Console.WriteLine("Press (C) to check the room for items");
                    Console.WriteLine("Press (I) to check your inventory");
                    Console.WriteLine("Press (F) to move to the next room");
                    Console.WriteLine("Press (S) to move to the other next room");
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