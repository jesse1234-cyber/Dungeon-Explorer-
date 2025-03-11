using System;
using System.Diagnostics;
using System.CodeDom;
using System.Media;

namespace DungeonExplorer
{
    public class NewPlayer // New class to allow for player to enter their own name
    {
        private static Player player;
        public static void InputName()
        {
           string playerName;
           while (true)
           {
                Console.WriteLine("Please enter the player's name: "); // Repeats line if given and empty input until a player enters a name
                playerName = Console.ReadLine(); 
                if (!string.IsNullOrEmpty(playerName))
                {
                    break;
                }
           }
           
           player = new Player(playerName, 100); // Setting and initialising Player name and health
        }
        public static Player GetPlayer() // Function allows for Game class to access player name to display it
        {
            return player;
        }
    }

    internal class Game
    {   
        private Room currentRoom = Room.room1; // Class attribute (within the class Game)

        public string startMessage; // attribute for Game()

        private Room.Items items; // Adding Items as an instance here. "items" is unused here. Remove?
        private Player player; //Added as an attribute
        public Game() // Constructor- these are the initial values
        {
            // Initialize the game with one room and one player
            startMessage = "Welcome to Dungeon Explorer! You find yourself in a strange room.";
            currentRoom = Room.room1; // To update variable later in the code when the user turns. Instead of GetDescription(), I'm using the implementation in a different way, as at this time it's easier for me to understand
            player = NewPlayer.GetPlayer();
        }
    
        private void StatusCheck() // Displays player's name, health, and their inventory
        {
            Console.WriteLine($"Name: {player.Name}, Health: {player.Health}"); // Player name displayed
            Console.WriteLine($"Inventory: {player.InventoryContents()}");
        }

        public void Start()
        {
            bool playing = true; // Changed to true (away from example). Return to false to end program (condition; if false, end game)
            while (playing) // assumes playing is true for this to execute.
            {
                Game currentPlay = new Game(); // currentPlay = object of Game, representative of a current playthrough during the running program
                Console.WriteLine(currentPlay.startMessage); // Welcomes user
                Console.WriteLine(currentRoom.description); // Displays room1's description
                Console.WriteLine("You can check your status (player name, health, and inventory) by typing 'status.'");
                
                string userInput = Console.ReadLine();
                if (string.Equals(userInput, "status", StringComparison.OrdinalIgnoreCase)) // Allows for input to be case-insensitive.
                {
                    StatusCheck();
                }
                
                currentRoom.InitializeRoomItems(); // The items get added to "availableItems" list for the user to pick up
                Debug.Assert(currentRoom.SelectItem() != null, "This should not return null!"); // Debugging to check if the item is null or not
                string item = currentRoom.SelectItem(); // Calls function via the object (instance of the class Items) items where an item randomly gets selected. Function changed to SelectItem() to be a failsafe if "items" returns null.

                string askPickUp;
                while (true)
                {
                    Console.WriteLine($"You look further to see {item}. Do you want to pick it up? yes/no.");
                    askPickUp = Console.ReadLine();
                    
                    if (string.Equals(askPickUp, "yes", StringComparison.OrdinalIgnoreCase)) // Allows for input to be case-insensitive.
                    {
                        player.PickUpItem(item);
                        playing = false;
                        break;
                    }
                    else if (string.Equals(askPickUp, "no", StringComparison.OrdinalIgnoreCase)) // Allows for input to be case-insensitive.
                    {
                        Console.WriteLine($"You did not pick up {item}. Your inventory remains empty.");
                        playing = false;
                        break;
                    }
                    else
                    {
                        Console.Write("You must enter either yes or no.");
                        playing = false;
                    }
                }
                
                //Ends game after the player picks up the object or not
                

                // Continuation for additional development
                // if (string.Equals(userInput, "left", StringComparison.OrdinalIgnoreCase))
                // {
                //     currentRoom = Room.room2; // Allow for an option for the user to go back to the starting room.
                // }

            }
        }
    }
}