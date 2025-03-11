using System;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Security.Authentication;

namespace DungeonExplorer
{
    internal class Game
    {
        private static Player player;
        

        public static void GameStart()                                                       // Initialize the game with one room and one player
        {
            
            player = new Player(100);
            player.CurrentRoom = new Room("Skulls shores");
            Console.WriteLine("Welcome to the Pirate Dungeon Explorer!");
            player.ShowHealth();
        }

        public static void StoryOpening()
        {
            Console.Clear();
            Console.WriteLine("You have entered the island by ship, instantly you notice two large caves shaped like skulls");          // Start of Story or Map
            Console.WriteLine("On the beach you notice two items glimmering in the distance so you walk over to take a look");
            Console.WriteLine("...\n There is a cutlass there, or an old musket. which do you pick up (cutlass/musket)");
            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                if (input == "cutlass")
                {
                    player.PickUpItem(new Item("cutlass", "A pirates right hand man"));
                    validInput = true;

                } else if (input == "musket")
                {
                    player.PickUpItem(new Item("musket", "An old rusty musket, but it will get the job done"));
                    validInput = true;


                }
                else
                {
                    Console.WriteLine("Invalid input please enter cutlass/musket ...");
                }
            }
            player.LevelNumber++;
        }

        public static void MoveRoomChoice()
        {

            Console.Clear();
            Console.WriteLine("The left cave has a old wooden sign reading 'Beware of the giant spider'");
            Console.WriteLine("The right cave has a rusted metal sign reading 'Beware of the giant snake'");
            Console.WriteLine("So .. ");                                                                           // Prompt user for room choice
            Console.WriteLine("Which cave would you like to enter? left or right");
            bool valid = false;
            do
            {
                string roomchoice = Console.ReadLine();

                if (roomchoice == "left")
                {
                    player.CurrentRoom = new Room("Giant Spider Pit");
                    valid = true;
                }
                else if (roomchoice == "right")
                {
                    player.CurrentRoom = new Room("Giant Snake Pit");
                    valid = true;
                }
                else
                    Console.WriteLine("Invalid Input: Please enter left or right...");                  // Exception handling prompt user to type correct input

            } while (!valid);


            Console.WriteLine("New Room: " + player.CurrentRoom.GetDescription());
        }

        public static void Maingameloop()
        {
            bool isPlaying = true;

            do
            {
                Console.Clear();
                Console.WriteLine("What would you like to do next...?:");

                Console.WriteLine("1. Continue with the story...");
                Console.WriteLine("2. View Current Health");
                Console.WriteLine("3. View Inventory");
                Console.WriteLine("4. View description of room");
                Console.WriteLine("5. Exit Game");
                Console.WriteLine("Enter your choice using 1 to 5:");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("You chose to continue with the story enjoy!");
                    if (player.LevelNumber == 1)
                    {
                        StoryOpening();
                    }
                    else if (player.LevelNumber == 2)
                    {
                        MoveRoomChoice();
                    }
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("You chose to View your current health");
                    player.ShowHealth();
                    Console.ReadLine();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("You chose to view your inventory");
                    player.InventoryContents();
                }
                else if (userInput == "4")
                {
                    Console.WriteLine("You chose to view the description of the room..." + player.CurrentRoom.GetDescription());
                    Console.ReadLine();
                }
                else if (userInput == "5")
                {
                    Console.WriteLine("You chose to Exit the game");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Choice, choose a number between 1 and 5");
                    Console.ReadLine();
                }

            } while (isPlaying);

        }
    }
}