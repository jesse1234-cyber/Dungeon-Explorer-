using System;
using System.Security.Policy;
using System.Threading;

namespace DungeonExplorer {
    internal class Game {
        private Player player;
        private Room currentRoom = RoomFactory.CreateRoomInstance("Library");

        public Player GetPlayer()
        {
            return player;
        }

        public void Start(Player player) {
            Console.WriteLine("Welcome to the Dungeon Explorer!\n");
            Console.WriteLine("What is your name?");
            this.player = new Player(Console.ReadLine(), 5);
            Console.WriteLine($"\nHello {player.GetName()}!\n\nBeginning your adventure...\n");
            Thread.Sleep(1000);
            bool playing = true;
            Console.WriteLine("You finally wake up. Your head is pounding, and the suffocating air, thick with dust, " +
                "clings to your lungs. Where are you? How did you get here? \n" +
                "(When prompted for a choice, you may type S, I or R into the console to see info about your" +
                "Status, Inventory, or the Room you are in! Or exit... :()");

            while (playing) {
                Thread.Sleep(3000);
                Console.WriteLine("\nYou look around.\n");
                Thread.Sleep(3000);
                string desc = currentRoom.GetDescription();
                string roomName = currentRoom.GetRoomName();
                int dialogue_count = 0;
                if (roomName == "Library" && dialogue_count < 1) {
                    Console.WriteLine($"Around you is... {desc}\n\nWhat do you do?\n" +
                    "A: Investigate the peculiar glistening\nB: Try to open the door\n" +
                    "C: Explore the rest of the library\n" +
                    "S, I, R, exit for other options!\n");
                }

                bool invalidChoice = true;
                while (invalidChoice) {
                    string userChoice = Console.ReadLine();

                    if (userChoice == "A")
                    {
                        invalidChoice = false;
                        player.PickUpItem("Mysterious Potion");
                        string inv = player.GetInventoryContents();
                        if (inv != "")
                        {
                            Console.WriteLine($"Your backpack contents are now {inv}!");
                        }
                    }

                    else if (userChoice == "B")
                    {
                        invalidChoice = false;
                        if (player.TryOpenDoor())
                        {
                            Console.WriteLine("You put the key in the lock, and it turns! The door creaks as you push it open...");
                            Console.WriteLine("...");
                            Thread.Sleep(1000);
                            Console.WriteLine("The end... for now");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("You try to turn the handle, but it doesn't budge. You should try to find a key...");
                        }
                    }

                    else if (userChoice == "C")
                    {
                        invalidChoice = false;
                        Thread.Sleep(1000);
                        Random rnd = new Random();
                        int itemRoll = rnd.Next(1, 10);
                        Console.WriteLine(itemRoll + "!");
                        if (itemRoll < 8)
                        {
                            string item = player.PickUpItem("Bone Key");
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
                        string inv = player.GetInventoryContents();
                        if (inv.Length == 0)
                        {
                            Console.WriteLine("Your inventory contains... cobwebs. It's empty.\n");
                        }
                        else
                        {
                            Console.WriteLine("Your inventory contains: " + inv);
                        }
                    }

                    else if (userChoice == "R")
                    {
                        invalidChoice = false;
                        Console.WriteLine(desc);
                        //int noItemsLeft = currentRoom.GetRoomContents();
                        //Console.WriteLine("There are " + noItemsLeft + " items left in the room!");
                    }

                    else if (userChoice == "S")
                    {
                        invalidChoice = false;
                        int hp = player.GetHealth();
                        Console.WriteLine($"You currently have {hp} health and you are in the {roomName}!");
                    }

                    else if (userChoice == "exit")
                    {
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



