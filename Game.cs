using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Handles game flow and user interaction
    /// </summary>
    internal class Game
    {
        private Player player;
        private Dictionary<string, Room> rooms;
        private Room currentRoom;
        private bool debugMode;
        private const string WELCOME_MESSAGE = "Welcome to Dungeon Explorer!";

        public Game(bool debugMode = false)
        {
            this.debugMode = debugMode;
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Only show welcome message in normal mode
            if (!debugMode)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(WELCOME_MESSAGE);
                Console.ResetColor();
                
                // Get player name and validate
                string playerName = "";
                bool validName = false;
                
                while (!validName)
                {
                    Console.Write("Enter your name: ");
                    playerName = Console.ReadLine()?.Trim();
                    
                    if (!string.IsNullOrWhiteSpace(playerName))
                    {
                        validName = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Name cannot be empty. Try again.");
                        Console.ResetColor();
                    }
                }
                
                // Create player with initial health
                player = new Player(playerName, 100);
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome, {player.Name}! Your adventure begins...");
                Console.WriteLine("Type 'help' to see available commands.");
                Console.ResetColor();
            }
            else
            {
                // Test player for debug mode
                player = new Player("TestPlayer", 100);
            }
            
            // Set up the dungeon
            CreateRooms();
            
            // Start in the entrance
            currentRoom = rooms["entrance"];
            
            if (!debugMode)
            {
                // Show initial room
                DisplayRoomInfo();
            }
        }

        // TODO: Add more rooms and make the dungeon more complex
        private void CreateRooms()
        {
            rooms = new Dictionary<string, Room>();
            
            // Create basic dungeon layout with generic descriptions
            var entrance = new Room("Entrance Hall", "An entrance hall to the dungeon. It's dimly lit with stone walls.");
            var corridor = new Room("Corridor", "A dungeon corridor that connects different rooms. It's dark and quiet.");
            var treasureRoom = new Room("Treasure Room", "A chamber that appears to hold various valuables.");
            
            // Add rooms to dictionary
            rooms.Add("entrance", entrance);
            rooms.Add("corridor", corridor);
            rooms.Add("treasureRoom", treasureRoom);
            
            // Set up connections between rooms
            entrance.AddExit("north", "corridor");
            corridor.AddExit("south", "entrance");
            corridor.AddExit("east", "treasureRoom");
            treasureRoom.AddExit("west", "corridor");
            
            // Add some basic items to rooms with generic descriptions
            entrance.AddItem(new Item("Key", "A key that might unlock something."));
            entrance.AddItem(new Item("Light Source", "A source of light useful for dark areas."));
            
            corridor.AddItem(new Item("Book", "A book containing written information."));
            
            treasureRoom.AddItem(new Item("Coin", "A circular piece of currency."));
            treasureRoom.AddItem(new Item("Amulet", "A decorative item that can be worn around the neck."));
            
            // Add some monsters with generic descriptions
            corridor.AddMonster(new Monster("Small Creature", "A small hostile creature that lives in the dungeon.", 20));
            treasureRoom.AddMonster(new Monster("Guardian", "A humanoid figure that appears to be protecting the treasure.", 50));
        }

        public void Start()
        {
            if (debugMode)
                return; // Skip the game loop in debug mode
            
            bool playing = true;
            
            // Main game loop
            while (playing)
            {
                try
                {
                    Console.Write("> ");
                    string input = Console.ReadLine()?.ToLower().Trim() ?? "";
                    
                    if (string.IsNullOrWhiteSpace(input))
                        continue;
                    
                    // Split input into command and args
                    string[] parts = input.Split(new[] { ' ' }, 2);
                    string cmd = parts[0];
                    string arg = parts.Length > 1 ? parts[1] : "";
                    
                    // Handle commands
                    switch (cmd)
                    {
                        case "look":
                            LookCommand();
                            break;
                        
                        case "go":
                        case "move":
                        case "walk":
                            GoCommand(arg);
                            break;
                        
                        case "take":
                        case "get":
                        case "grab":
                            TakeCommand(arg);
                            break;
                        
                        case "status":
                        case "stats":
                            StatusCommand();
                            break;
                        
                        case "i":
                        case "inv":
                        case "inventory":
                            InventoryCommand();
                            break;
                        
                        case "x":
                        case "examine":
                        case "look at":
                            ExamineCommand(arg);
                            break;
                            
                        case "?":
                        case "help":
                            HelpCommand();
                            break;
                        
                        case "exit":
                        case "quit":
                        case "bye":
                            Console.WriteLine("Thanks for playing Dungeon Explorer!");
                            playing = false;
                            break;
                        
                        default:
                            Console.WriteLine("Huh? I don't understand that command. Try 'help' for options.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Basic error handling
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Oops! Something went wrong: {ex.Message}");
                    Console.ResetColor();
                    
                    if (debugMode)
                    {
                        // Only show stack trace in debug mode
                        Console.WriteLine($"Stack trace: {ex.StackTrace}");
                    }
                }
            }
        }

        private void LookCommand()
        {
            DisplayRoomInfo();
        }

        private void DisplayRoomInfo()
        {
            // Room name and description
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(currentRoom.GetDescription());
            Console.ResetColor();
            
            // Show items in the room
            if (currentRoom.HasItems())
            {
                Console.WriteLine("\nYou see:");
                foreach (var item in currentRoom.GetItems())
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
            
            // Show monsters in the room
            if (currentRoom.HasMonsters())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBeware of:");
                foreach (var monster in currentRoom.GetMonsters())
                {
                    Console.WriteLine($"- {monster.Name}");
                }
                Console.ResetColor();
            }
            
            // Show available exits
            Console.WriteLine("\nExits:");
            foreach (var exit in currentRoom.GetExits())
            {
                Console.WriteLine($"- {exit.Key}");
            }
        }

        private void GoCommand(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
            {
                Console.WriteLine("Go where? Try north, south, east, or west.");
                return;
            }
            
            // Check if exit exists
            string destKey = currentRoom.GetExitRoom(direction);
            if (destKey != null)
            {
                // Move to new room
                currentRoom = rooms[destKey];
                Console.WriteLine($"You go {direction}.");
                DisplayRoomInfo();
            }
            else
            {
                Console.WriteLine($"There's no exit to the {direction}.");
            }
        }

        private void TakeCommand(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Take what? Be specific.");
                return;
            }
            
            // Find item in room
            var item = currentRoom.GetItem(itemName);
            if (item != null)
            {
                // Add to inventory if possible
                if (player.PickUpItem(item))
                {
                    currentRoom.RemoveItem(item);
                    Console.WriteLine($"You pick up the {item.Name}.");
                }
                else
                {
                    Console.WriteLine("Your inventory is full!");
                }
            }
            else
            {
                Console.WriteLine($"There's no {itemName} here.");
            }
        }

        private void StatusCommand()
        {
            Console.WriteLine($"Name: {player.Name}");
            
            // Show health with color based on amount
            Console.Write("Health: ");
            
            if (player.Health > 75)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (player.Health > 30)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
                
            Console.WriteLine(player.Health);
            Console.ResetColor();
            
            InventoryCommand();
        }

        private void InventoryCommand()
        {
            if (player.HasItems())
            {
                Console.WriteLine("Inventory:");
                foreach (var item in player.GetInventory())
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.");
            }
        }

        private void ExamineCommand(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                Console.WriteLine("Examine what? Specify an item or monster.");
                return;
            }
            
            // Check inventory first
            var invItem = player.GetItem(target);
            if (invItem != null)
            {
                Console.WriteLine(invItem.Description);
                return;
            }
            
            // Check room for items
            var roomItem = currentRoom.GetItem(target);
            if (roomItem != null)
            {
                Console.WriteLine(roomItem.Description);
                return;
            }
            
            // Check room for monsters
            var monster = currentRoom.GetMonster(target);
            if (monster != null)
            {
                Console.WriteLine(monster.Description);
                return;
            }
            
            Console.WriteLine($"You don't see any {target} here.");
        }

        private void HelpCommand()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== COMMANDS =====");
            Console.ResetColor();
            Console.WriteLine("  look               - Look around the room");
            Console.WriteLine("  go [direction]     - Move in a direction (north, south, etc.)");
            Console.WriteLine("  take [item]        - Pick up an item");
            Console.WriteLine("  status             - Check your health and inventory");
            Console.WriteLine("  inventory (or inv) - List your items");
            Console.WriteLine("  examine [thing]    - Get details about an item or monster");
            Console.WriteLine("  help               - Show this help");
            Console.WriteLine("  exit (or quit)     - Exit the game");
        }
        
        // For testing purposes
        public Player GetPlayer() => player;
        public Room GetCurrentRoom() => currentRoom;
        public Dictionary<string, Room> GetRooms() => rooms;
    }
}
        }
    }
}
