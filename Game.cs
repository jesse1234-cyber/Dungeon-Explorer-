using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Runtime.Remoting;


namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room current_room;
        private List<Room> visited_rooms = new List<Room>();

        public Game()
        {
            // Initialize the game with one room and one player
            this.player = new Player("PLACE HOLDER", 100);
            this.current_room = new Room();
        }


        public void Menu() 
        {
            // Menu Loop
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                string menu_txt = @"
=================================================
                  RUST & RUIN
=================================================

In a forgotten realm consumed by corrosion and decay, each 
door leads deeper into the ruins of a kingdom lost to time. 
Monsters lurk in shadowed corridors, and only those brave 
enough can uncover the secrets hidden within.

Will you press on through the rust and ruin, or will you 
succumb to the darkness?

1. Enter the Ruins
2. How to Play
3. Abandon Quest
4. Quit
Choose your fate [1 - 4]";

                List<string> menu_options = new List<string>() { "1", "2", "3", "4" };
                string menu_input = this.GetOption(menu_options, menu_txt);

                switch (menu_input)
                {
                    case "1":
                        /// <summary>
                        /// New/Continue Game
                        /// Will create a new game or continue from a previous game.
                        /// </summary>

                        this.Start();
                        break;
                    case "2":
                        /// <summary>
                        /// How to play
                        /// Will create a new game or continue from a previous game.
                        /// </summary>
                        Console.WriteLine("How to Play...");
                        Console.WriteLine("Waiting for Implementation");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;

                    case "3":
                        /// <summary>
                        /// Delete save game
                        /// Will create a new game or continue from a previous game.
                        /// </summary>
                        Console.WriteLine("Delete Game...");
                        Console.WriteLine("Waiting for Implementation");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;

                    case "4":
                        /// <summary>
                        /// Quit game
                        /// Asks the user if they are sure they want to quit
                        /// </summary>

                        Console.WriteLine("Are you sure you want to quit? Y/N");
                        Console.Write("\n :: ");
                        string quit_input = Console.ReadLine().ToUpper();

                        if (quit_input == "Y")
                        {
                            Environment.Exit(0);
                        }

                        continue;

                    default:
                        /// <summary>
                        /// Will exit the program if the menu option fails to be processed
                        /// </summary>

                        Console.WriteLine("Error processing menu input, quitting.");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                }

            }
        }

        private void Start()
        {
            // If no save is present generate a new one.
            if (!CallSave("REPLACE ME PLEASEEEE!!!!!!!!"))
            {
                this.NewGame();
            }

            // If there is CallSave() will get relevant information
            // Then carry on with the game
            this.GameLoop();
        }


        #region Menu Control

        public string GetOption(List<string> valid_inputs, string output)
        {
            /// <summary>
            /// Function that gets an input from the user.
            /// Recursive function that calls on itself on a erroneous input.
            /// </summary>
            
            // Output message and get user input
            Console.WriteLine(output);
            Console.Write("\n :: ");
            string input = Console.ReadLine();

            // Check if it is a valid input
            if (valid_inputs.Contains(input))
            {
                // Return the users choice
                return input;
            }
            // If not notify user and call on itself 
            else
            {
                Console.WriteLine("Please enter a valid option.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return GetOption(valid_inputs, output);
            }
        }


        #endregion

        #region Game Control

        public void NewGame()
        {
            // New Game

            string title_str = @"
=================================================
                  RUST & RUIN                  
=================================================
";

            // Display intro.
            string intro_txt = $@"{title_str}

The world you know is fading, devoured by rust, decay, and time.  
Once-thriving civilisations now lie buried beneath dunes of  
corroded steel and forgotten ruins. Towering constructs from  
a bygone age stand silent, their gears jammed, their  
purposes lost to memory.

In this land of ruin, survival is both a battle and a burden.  

You are a survivor, a wanderer of the Rustlands. Each step  
brings you closer to the heart of the decay—a sprawling  
labyrinth of ancient chambers and forgotten vaults known  
as the Iron Maw.

=================================================";
            Console.Clear();
            Console.WriteLine(intro_txt);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            
            // Get the name from the user.
            player.GetName();
            Console.Clear();
            Console.WriteLine($"{title_str}\n\nWelcome to the Iron Maw {player.Name}!");
            Console.WriteLine("I wish you luck wanderer...");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            // Enter first room.
            Console.Clear();
            string first_room_txt = $@"{title_str}

The sound of groaning metal fills the air as you step into the ruins. 
Rust clings to every surface, and decay has claimed all that was once 
strong and whole. Yet, in this desolation, a faint glimmer of hope 
remains a legend of power hidden deep within the labyrinth. 

You are an adventurer, seeking answers, treasure, or perhaps redemption. 
Before you lies a series of rooms, each more treacherous than the last. 

Do you have what it takes to navigate the dangers, claim the treasure, 
and uncover the secrets of the Rust & Ruin?";
            Console.WriteLine(first_room_txt);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }

        private void GameLoop()
        {
            bool loop = true;
            
            while (loop)
            {
                Console.Clear();

                visited_rooms.Add(current_room);

                current_room.DisplayRoom(player);
            }
        }

        #endregion

        #region Display Control

        #endregion

        #region Save Control

        public void SaveGame(string path)
        {

        }

        public void DeleteSave(string path)
        {

        }

        public bool CallSave(string path)
        {
            return false;
        }

        #endregion

    }
}