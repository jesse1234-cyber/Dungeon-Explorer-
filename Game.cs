using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Dictionary<string, Room> dungeon;
        
        public Game()
        {
            // Initialize rooms and player
            InitializeDungeon();
            player = new Player("Hero");
            currentRoom = dungeon["Entrance"];
        }

        private void InitializeDungeon()
        {
            dungeon = new Dictionary<string, Room>();
            
            Room entrance = new Room("Entrance", "A dimly lit room with a wooden door.");
            Room hall = new Room("Hall", "A grand hall with torches on the walls.");
            Room armory = new Room("Armory", "A room filled with old weapons and armor.");
            Room treasure = new Room("Treasure Room", "A glittering room filled with gold and jewels.");

            entrance.Exits["north"] = hall;
            hall.Exits["south"] = entrance;
            hall.Exits["east"] = armory;
            hall.Exits["west"] = treasure;
            armory.Exits["west"] = hall;
            treasure.Exits["east"] = hall;
            
            dungeon["Entrance"] = entrance;
            dungeon["Hall"] = hall;
            dungeon["Armory"] = armory;
            dungeon["Treasure Room"] = treasure;
        }

        public void Start()
        {
            bool playing = true;
            Console.WriteLine("Welcome to Dungeon Explorer!");

            while (playing)
            {
                Console.WriteLine($"You are in {currentRoom.Name}. {currentRoom.Description}");
                Console.WriteLine("What do you want to do? (move [direction], look, quit)");
                string input = Console.ReadLine().ToLower();
                
                if (input.StartsWith("move "))
                {
                    string direction = input.Substring(5);
                    Move(direction);
                }
                else if (input == "look")
                {
                    Console.WriteLine(currentRoom.Description);
                }
                else if (input == "quit")
                {
                    playing = false;
                    Console.WriteLine("Thanks for playing!");
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }

        private void Move(string direction)
        {
            if (currentRoom.Exits.ContainsKey(direction))
            {
                currentRoom = currentRoom.Exits[direction];
                Console.WriteLine($"You move {direction} to {currentRoom.Name}.");
            }
            else
            {
                Console.WriteLine("You can't go that way!");
            }
        }
    }

    internal class Player
    {
        public string Name { get; private set; }
        public Player(string name)
        {
            Name = name;
        }
    }

    internal class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, Room> Exits { get; private set; }
        
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
        }
    }

    class Program
    {
        static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}
