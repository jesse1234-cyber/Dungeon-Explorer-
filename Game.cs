using System;
using System.CodeDom;
using System.Media;

namespace DungeonExplorer
{
    public class NewPlayer // New class to allow for player to enter their own name
    {
        private static Player player;
        public static void InputName()
        {
           Console.WriteLine("Please enter the player's name: ");
           string playerName = Console.ReadLine(); 
           player = new Player(playerName, 100); // Setting and initialising Player name and health
        }
        public static Player GetPlayer() // Function allows for Game class to access player name to print it
        {
            return player;
        }
    }

    internal class Game
    {   
        private Room currentRoom; // Class attribute (within the class Game) Aim for four rooms, game can be simple and easy

        public string startMessage; // attribute for Game()

        private Room.Items items; // Adding Items as an instance here. "items" is unused here. Remove?
        private Player player; //Added as an attribute
        public Game() // Constructor- these are the initial values
        {
            // Initialize the game with one room and one player
            startMessage = "Welcome to Dungeon Explorer! You find yourself in a strange room.";
            currentRoom = Room.room1; // !!To update variable later in the code when the user turns.
            player = NewPlayer.GetPlayer();
        }
    
        private void StatusCheck() // Displays player's name, health, and their inventory
        {
            Console.WriteLine($"Name: {player}, Health: {player.Health}"); // !!Test if this displays appropiately
            Console.WriteLine($"Inventory: {player.InventoryContents()}");
        }

        // Try execept for erroneous input (within "Start" method)
        // Should there be a new method for a main gameplay loop?- and just have Start() as intialisation of a Room- or would the code base be too small?
        public void Start()
        {
            bool playing = true; // Changed to true (away from example). Return to false to end program (condition; if false, "break" aka end game)
            while (playing) // assumes playing is true for this to execute. Becomes false once user finds the key and exits the door, as well as a congratulations message.
            {
                // !Code your playing logic here
                Game currentPlay = new Game(); // currentPlay = object of Game, representative of a current playthrough during the running program
                Console.WriteLine(currentPlay.startMessage); // Welcomes user
                Console.WriteLine(currentRoom.description); // Displays room1's description
                Console.WriteLine("You can check your status (player name, health, and inventory) by typing 'status.'");
                currentRoom.InitializeRoomItems(); // The items get added to "availableItems" list for the user to pick up

                // !!! HERE; An if statement here to check what is input goes against the game (displaying status, pickup item function, moving rooms)
                string userInput = Console.ReadLine();
                if (string.Equals(userInput, "status", StringComparison.OrdinalIgnoreCase)) // Allows for input to be case-insensitive.
                {
                    StatusCheck();
                }

                if (string.Equals(userInput, "left", StringComparison.OrdinalIgnoreCase))
                {
                    currentRoom = Room.room2; // Allow for an option for the user to go back to the starting room.
                }

            }
        }
    }
}