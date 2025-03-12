using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            player = new Player("PlayerName", 100);
            
            currentRoom = new Room( "The room is cold and musty, a rusted iron cage sits in the corner, empty but unsettling. There is a potion on the floor.", new List<string> { "potion" });

        }
        public void Start()
        {
            
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Type 1 to start");
                Console.WriteLine("Type 2 to exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Welcome!");
                        GameRun();
                        playing = false;
                        break;

                    case "2":
                        Console.WriteLine("Thanks for playing");
                        playing = false;
                        break;
                       

                    default:
                        Console.WriteLine("Please input one of the given keys");
                        break;
                        



                }
            }
        }

        private void GameRun()
        {
            

            Console.WriteLine("What would you like to do?");
            commands();
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "grab item":
                    Console.WriteLine("Enter the name of the item you would like to pick up: ");
                    string item = Console.ReadLine().ToLower();
                    if (currentRoom.GetItems().Contains(item))
                    {
                        player.addItem(item);
                        currentRoom.RemoveItems(item);
                    }
                    else
                    {
                        Console.WriteLine("item not found");
                    }
                    break;
                    
                
                case "player":
                    playerOptions();
                    break;

                case "surroundings":
                    surroundings();
                    break;
                
                case "exit":
                    Exit();
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;

                
            }
        }

        private void commands()
        {
            Console.WriteLine("grab item - pick up a given item");
            Console.WriteLine("player - gives options to do with the player (iventory, health or change name)");
            Console.WriteLine("surroundings - check the room you are in");
            Console.WriteLine("exit - leave the game");
        }

        private void playerOptions()
        {
            Console.WriteLine("Would you like to check health, inventory or name");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "inventory":
                    player.showInv();
                    GameRun();
                    break;
                case "health":
                    player.ShowHealth();
                    GameRun();
                    break;
                case "name":
                    nameSettings();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;

            }
        }

        private void nameSettings()
        {
            Console.WriteLine("Would you like to 'check' or 'change' your name");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "check":
                    Console.WriteLine($"Your name is, {player.Name}");
                    break;
                case "change":
                    Console.WriteLine("Please enter your new name: ");
                    player.Name = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;

            }

            GameRun();
        }

        private void surroundings()
        {
            Console.WriteLine(currentRoom.GetDescription());
            GameRun();
        }

        private void Exit()
        {
            Console.WriteLine($"Thanks for playing, {player.Name}!");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}