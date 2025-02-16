using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Map map;

        public Game()
        {
            // Initialize the game with one room and one player

        }
        public void Start()
        {
            bool nameSelect = true;
            bool playing = false;
            string name = "";
            

            // Code for selecting name for the character
            while (nameSelect)
            {
                Console.Write("What is your character's name: ");
                name = Console.ReadLine();
                Console.WriteLine($"Is {name} the right name? y/n");
                string desision = Console.ReadLine().ToLower();
                if (desision == "y") nameSelect = false;
            }

            // Initalise Player Class
            player = new Player(name, 10);
            //Initalise Starting Room Class
            currentRoom = new Room(0,0);
            
            //Initalise Map Class
            map = new Map(3,3,currentRoom);
            
            //Allow Entry into main game Loop
            playing = true;
            
            // Main Game loop
            while (playing)
            {
                // Main Game Menu
                string command = "";
                Console.WriteLine("Commands:");
                Console.WriteLine("1) Check Inventory");
                Console.WriteLine("2) Move");
                Console.WriteLine("3) Room Info Menu");
                Console.WriteLine("4) Search Room");
                Console.WriteLine("5) View Map");
                Console.WriteLine("6) Exit Game");
                Console.WriteLine("Choose a command (check, move, room, search, map, exit): ");
                Console.Write("> ");
                // Get Main Game Menu Command
                command = Console.ReadLine().ToLower();

                // Check if main game menu command is valid
                if (command == "check")
                {
                    string inventory = player.InventoryContents();
                    Console.WriteLine($"Inventory: {inventory}");
                }
                else if (command == "move")
                {
                    // Move to a new room
                    currentRoom = map.changeRoom(currentRoom);
                }
                else if (command == "room")
                {
                    // Room Info Menu
                    currentRoom.RoomInfoMenu();
                }
                else if (command == "search")
                {
                    // Search the room
                    player = currentRoom.SearchRoom(player);
                }
                else if (command == "map")
                {
                    // View the map
                    map.DisplayMap();
                }
                else if (command == "exit")
                {
                    // Exit the game
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

    }
}