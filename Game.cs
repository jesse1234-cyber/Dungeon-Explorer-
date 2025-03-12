using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Player", 100);
            Room room1 = new Room("You are in a dungeon.There is a diamond sword on the ground near by.");
            Room room2 = new Room("You are in a dungeon.There is a gold sword on the ground near by.");
            Room room3 = new Room("You are in a dungeon.There is a wooden sword on the ground near by.");
            
            currentRoom.AddItem("sword"); // creates a sword.
            room1.AddItem("diamond sword");
            room2.AddItem("gold sword");
            room3.AddItem("wooden sword");

            room1.AddConnectedRoom("north", room2);
            room2.AddConnectedRoom("south", room1);


            //sets starting room.
            currentRoom = room1;
        }   
        public void Start()
        {
            Console.WriteLine("Dungeon Explorer"); //displays the title of the game.
            bool playing = true; // this will check to see if the game is still running
            while (playing)
            {
              // Shows the current room info
              Console.WriteLine(currentRoom.GetDescription());
              Console.WriteLine("Items in room: " + currentRoom.ListItems());
                // Shows available exits
              Console.WriteLine("Exits: " + currentRoom.ListConnectedRooms());
                // make the player choose an option
              Console.WriteLine("Pick one of these options below");
              Console.WriteLine("Options: 1.'pick up {item}', 2.'inventory', 3.'move [direction]', 'exit'");

                // player input
                string input = Console.ReadLine().ToLower();

                // this will process the player input
                if (input.StartsWith("pick up"))
                {
                    string item = input.Substring(8).Trim();
                    if (currentRoom.ListItems().Contains(item))
                    {
                        currentRoom.RemoveItem(item); ; // removes item from room.
                        player.PickUpItem(item); // adds item to players inventory.
                    }
                    else
                    {
                        Console.WriteLine($"{item} is not in this room.");
                    }
                }
                else if (input == "inventory")
                {
                    // display the player inv
                    Console.WriteLine("Your inventory: " + player.InventoryContents());
                }
                else if (input.StartsWith("move"))
                {
                    string direction = input.Substring(5).Trim();
                    Room nextRoom = currentRoom.GetConnectedRoom(direction);
                    if (nextRoom != null)
                    {
                        currentRoom = nextRoom;
                        Console.WriteLine($"You moved to the {direction}");
                    }
                    else
                    {
                        Console.WriteLine("You cannot go that way.");
                    }
                }
                else if (input == "exit")
                {
                    // exit game
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                }
                else
                {
                    //handle invalid inputs
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}