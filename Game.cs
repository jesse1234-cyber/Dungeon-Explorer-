using System;
using System.Threading;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing the main Game logic and responsible for creating instances of the 
    /// <see cref="Room"/> and <see cref="RoomFactory"/> classes.
    /// </summary>
    internal class Game
    {
        private Player player;
        private readonly Room currentRoom = RoomFactory.CreateRoomInstance("Library");

        /// <summary>
        /// Begins the game and all the logic and text that follows.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to the Dungeon Explorer!\n");
            Console.WriteLine("What is your name?");
            this.player = new Player(Console.ReadLine(), 5);
            Console.WriteLine($"\nHello {this.player.GetName()}!\n\nBeginning your adventure...\n");
            Thread.Sleep(1000);
            bool playing = true;
            Console.WriteLine("You finally wake up. Your head is pounding, and the suffocating air, thick with dust, " +
                "clings to your lungs. Where are you? How did you get here? \n" +
                "\n(When prompted for a choice, you may type S, I or R into the console to see info about your " +
                "Status, Inventory, or the Room you are in, and if you wish to leave the game, type exit!)\n");

            while (playing)
            {
                Thread.Sleep(3000);
                string desc = currentRoom.GetDescription();
                string roomName = currentRoom.GetName();

                Console.WriteLine($"You look around: {desc}");
                Console.WriteLine("What do you do next?");

                bool invalidChoice = true;
                while (invalidChoice)
                {
                    string userChoice = Console.ReadLine().ToUpper();

                    // Handling the user's choices and playing the corresponding scenario
                    if (userChoice == "A")
                    {
                        invalidChoice = false;
                        string item = "Mysterious Potion";
                        Console.WriteLine($"\nThe glistening turned out to be a {item}! You try to grab it off the shelf...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Rolling dice... Roll a number that is smaller than 8 to pick up the item!");
                        Thread.Sleep(1000);
                        Console.WriteLine("You rolled...\n");
                        Thread.Sleep(1000);
                        Random rnd = new Random();
                        int itemRoll = rnd.Next(1, 10);
                        Console.WriteLine(itemRoll + "!");
                        if (itemRoll < 8)
                        {
                            this.player.PickUpItem(item);
                            Thread.Sleep(1000);
                            Console.WriteLine($"You carefully put the {item} in your backpack.\n");
                        }
                        else
                        {
                            Console.WriteLine("Oops! A huge spider crawls out from behind the item, startling you." +
                                "You drop the item onto the floor, and it gets stuck under a bookshelf.\n");
                        }
                        if (!this.player.IsInvEmpty())
                        {
                            Console.WriteLine($"Your inventory contents are now: {this.player.GetInventoryContents()}\n");
                        }
                    }

                    else if (userChoice == "B")
                    {
                        invalidChoice = false;
                        if (this.player.TryOpenDoor())
                        {
                            Console.WriteLine("You put the key in the lock, and it turns! The door creaks as you push it open...");
                            Console.WriteLine("...");
                            Thread.Sleep(1000);
                            Console.WriteLine("The end... for now!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("You try to turn the handle, but it doesn't budge. You should try to find a key...");
                        }
                    }

                    else if (userChoice == "C")
                    {
                        string item = "Bone Key";
                        Console.WriteLine($"\nThe glistening turned out to be a {item}! You try to grab it off the shelf...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Rolling dice... Roll a number that is smaller than 8 to pick up the item!");
                        Thread.Sleep(1000);
                        Console.WriteLine("You rolled...\n");
                        invalidChoice = false;
                        Thread.Sleep(1000);
                        Random rnd = new Random();
                        int itemRoll = rnd.Next(1, 10);
                        Console.WriteLine(itemRoll + "!");
                        if (itemRoll < 8)
                        {
                            this.player.PickUpItem(item);
                            Thread.Sleep(1000);
                            Console.WriteLine($"You carefully put the {item} in your backpack.\n");
                        }
                        else
                        {
                            Console.WriteLine("Oops! A huge spider crawls out from behind the item, startling you." +
                                "You drop the item onto the floor, and it gets stuck under a bookshelf.\n");
                        }
                    }

                    else if (userChoice == "I")
                    {
                        invalidChoice = false;
                        Console.WriteLine("You open your backpack...");
                        if (this.player.IsInvEmpty())
                        {
                            Console.WriteLine("Your inventory contains... cobwebs. It's empty.\n");
                        }
                        else
                        {
                            Console.WriteLine("Your inventory contains: " + this.player.GetInventoryContents());
                        }
                    }

                    else if (userChoice == "R")
                    {
                        invalidChoice = false;
                        Console.WriteLine(desc);
                    }

                    else if (userChoice == "S")
                    {
                        invalidChoice = false;
                        int hp = this.player.GetHealth();
                        Console.WriteLine($"You currently have {hp} health and you are in the {roomName}!");
                    }

                    else if (userChoice == "EXIT")
                    {
                        invalidChoice = false;
                        return;
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid option!");
                    }
                }
            }
        }
    }
}



