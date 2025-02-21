using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player = new Player();
        private Room currentRoom = new Room();

        public Game()
        {
            Console.Write("Enter the player name: ");
            string new_name = Console.ReadLine();
            player.Name = new_name;
            player.Health = 100;
            currentRoom.Description = "The room is dark, the only thing you can see is a little glow in the corner of the room.";

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Type help for a list of commands");
                Console.Write("Enter command: ");
                string user_input = Console.ReadLine().ToLower();
                if (user_input == "help")
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("Status - displays the players' name, health and inventory.");
                    Console.WriteLine("Description - displays the description of the room.");
                    Console.WriteLine("Quit - exits the game.");
                }
                else if (user_input == "status")
                {
                    Console.WriteLine("Name: " + player.Name);
                    Console.WriteLine("Health: " + player.Health);
                    Console.WriteLine("Inventory: " + player.InventoryContents());
                }
                else if (user_input == "description")
                {
                    Console.WriteLine(currentRoom.GetDescription());
                    Console.Write("Do you want to inspect the glowing thing? (Y/N): ");
                    string choice_1 = Console.ReadLine().ToUpper();
                    if (choice_1 == "Y")
                    {
                        Console.Write("You inspect the glow, it turns out to be a key. Do you want to pick up the key? (Y/N): ");
                        string choice_2 = Console.ReadLine().ToUpper();
                        if (choice_2 == "Y")
                        {
                            player.PickUpItem("Key");
                            Console.WriteLine("Player Inventory: " + player.InventoryContents());

                        }
                        else if (choice_2 == "N")
                        {
                            Console.WriteLine("You decide not to pick up the key.");

                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (choice_1 == "N")
                    {
                        Console.WriteLine("You decide not to inspect the glowing thing.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }

                }
                else if (user_input == "quit")
                {
                    Console.WriteLine("Exiting....");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}