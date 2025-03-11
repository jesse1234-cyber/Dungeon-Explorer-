using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Media;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Monster monster;

        public Game()
        {
            // Initialize the game with a room, a player, and a monster, and sets their health values. 
            currentRoom = new Room("You enter a dim room and are faced with a huge slug-like monster! You notice a shimmering item on the floor...");
            player = new Player("Player", 100);
            monster = new Monster("ScarySlug", 50);
        }
        public void Start()
        {
            // This is the main part of the program, which will iterate whilst the playing condition is true and monster health is greater than 0. 
            bool playing = true;
            Console.WriteLine(currentRoom.RoomDescription());
            while (playing == true)
            {
                while (monster.GetHealth() > 0)
                {
                    // Lines 34 and 35 write the current player and monster health to the console each time the loop iterates. 
                    Console.WriteLine($"Your current health is: {player.ShowHealth()}");
                    Console.WriteLine($"Scary slug current health is: {monster.GetHealth()}");

                    // Line 38 assigns the user input from the ExplorerInput() function so that it can be used in the conditions below. 
                    string input = this.ExplorerInput();

                    // The following conditional statements call the appropriate methods in relation to what action the user has chosen to take. 
                    if (input == ("d"))
                    {
                        Console.WriteLine(monster.Damage());
                    }
                    else if (input == ("s") && player.FindItems() == false)
                    {
                        string PlayerInv = currentRoom.RoomItems();
                        player.FindItems(PlayerInv);
                        Console.WriteLine($"On the floor, there was {PlayerInv} and you picked it up.");
                    }
                    else if (input == ("b") && player.FindItems() == true)
                    {
                        Console.WriteLine($"Your backpack contains: {player.Backpack()}");
                        Console.WriteLine("Enter u to use the key to unlock a door or r to return it to the backpack.");
                        string secondInput = Console.ReadLine();
                        if (secondInput == ("r"))
                        {
                            Console.WriteLine("Key has been returned to backpack");
                        }
                        else if (secondInput == ("u"))
                        {
                            Console.WriteLine("Door one is made of rotting wood and is covered in rust and moss. Door two is made of shiny metal.");
                            Console.WriteLine("Enter 1 to try the key in door one.");
                            Console.WriteLine("Enter 2 to try the key in door two.");
                            string doorChoiceInput = Console.ReadLine();
                            if (doorChoiceInput == ("1"))
                            {
                                // This option is one of the two path choices that allows the player to exit the dungeon and "win" the game, killing the slug and exiting the game. 
                                Console.WriteLine("The key fits! With a little force, the door opens to reveal a forest bathed in sunlight.");
                                Console.WriteLine("The scary slug follows you out! You give it a final attack!");
                                while (monster.GetHealth() > 0)
                                {
                                    monster.Damage();
                                }
                                Console.WriteLine("Congratulations, you have escaped the dungeon and won the game!");
                                playing = false;
                                break;
                                
                            }
                            if (doorChoiceInput == ("2"))
                            {
                                Console.WriteLine("Regardless of how hard you try, the key does not fit and the door will not open.");
                                Console.WriteLine("In the time it took you to try the door, the scary slug regained 10 health.");
                                monster.Heal();
                                
                            }
                        }
                    }
                    else if (input == ("e"))
                    {
                        Console.WriteLine(player.Eat());
                    }

                    else
                    {
                        // If the user enters a character that is not an option, this statement will tell them to choose a letter above. 
                        Console.WriteLine("Please input a letter from the options above.");
                    }
                    playing = false;
                }
                // Damaging the monster until its health is less than 0 is the second path to win the game. 
                Console.WriteLine("You have killed the Scary Slug.");
                Console.WriteLine("Congratulations, you have won the game!");

            }



        }
        private string ExplorerInput()
        {
            // This section presents the user with their options and returns their choice as the variable 'input' that is used above. 
            Console.WriteLine("From here, you can choose from the following options:");
            Console.WriteLine("Enter d to deal damage");
            Console.WriteLine("Enter e to eat food and regain health");

            // The conditional statements below makes sure that whilst the user hasn't searched for items, they can't use them. 
            // It won't give them the option to view the backpack contents, and consequently unlock any doors, until they have searched for items. 
            if (player.FindItems() == false)
            {
                Console.WriteLine("Enter s to search for items");
            }
            if (player.FindItems() == true)
            {
                Console.WriteLine("Enter b to view the backpack contents");
            }

            // The 2 lines of code below assigns the user's input as a string to the value 'input' to be used in the main game program. 
            string input = Console.ReadLine();
            return input;
        }
    }
}
