using System;
using System.Globalization;
using System.Media;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Player enemy;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player

            bool inOptions = true;

            while (inOptions = true)
            {
                try
                {
                    Console.WriteLine("Please enter a username: ");
                    string playerUsername = Console.ReadLine();
                    player = new Player(playerUsername, 100);

                    if (playerUsername.Length == 0)
                    {
                        throw new NullReferenceException("Username cannot be empty");
                    }

                    else
                    {
                        break;
                    }

                }

                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.WriteLine($"Welcome {player.Name}");
            currentRoom = new Room("The room is cold and dark, with goblins crawling everywhere");
            enemy = new Player("goblin", 50); 
        }
            
            
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            Console.WriteLine("Entering Dungeon...");
            Console.WriteLine(currentRoom.GetDescription());
            Console.WriteLine("You can enter 'M' to view the description at any time");
            


            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                string item;

                bool lootingRoom = true;
                while (lootingRoom)
                {
                    

                    try
                    {
                        Console.WriteLine("Press A to move right, D to move left or W to move forward");
                        string userMoveInput = Console.ReadLine();
                        if (userMoveInput == "A")
                        {
                            Console.WriteLine("Moving to the right");
                            Console.WriteLine("You have found a golden sword");
                            item = "A golden sword";
                            player.PickUpItem(item);
                            Console.WriteLine($"The contents of your inventory are: {player.InventoryContents()}");
                            lootingRoom = false;
                        }

                        else if (userMoveInput == "D")
                        {
                            Console.WriteLine("Moving to the left");
                            Console.WriteLine("You have found a bow and arrow");
                            item = "A bow and arrow";
                            player.PickUpItem(item);
                            Console.WriteLine($"The contents of your inventory are: {player.InventoryContents()}");
                            lootingRoom = false;
                        }

                        else if (userMoveInput == "W")
                        {
                            Console.WriteLine("Moving forwards");
                            Console.WriteLine("You have found an axe");
                            item = "Axe";
                            player.PickUpItem("Axe");
                            Console.WriteLine($"The contents of your inventory are: {player.InventoryContents()}");
                            lootingRoom = false;
                        }

                        else if (userMoveInput == "M")
                        {
                            Console.WriteLine(currentRoom.GetDescription());
                        }

                        else
                        {
                            throw new ArgumentOutOfRangeException("Please enter A, D or W to move");
                        }
                    }

                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                    
                

                Console.WriteLine($"a {enemy.Name} is approaching...");

                Console.WriteLine("Press 'I' to view inventory, press any other key to ignore");
                string viewInventory = Console.ReadLine();

                try
                {
                    if (viewInventory == "I")
                    {
                        Console.WriteLine($"The contents of your inventory are: {player.InventoryContents()}");
                        Console.WriteLine($"To attack the {enemy.Name} you must enter 'F'");
                    }

                    else
                    {
                        throw new Exception($"To attack the {enemy.Name} you must enter 'F'");
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                
                bool battle = true;
                

                while (battle)
                {
                    Random enemyRandomAttack = new Random();
                    int enemyDamage = enemyRandomAttack.Next(10, 30);
                    Console.WriteLine("The goblin has attacked");
                    player.Health -= enemyDamage;

                    if (player.Health > 0)
                    {
                        Console.WriteLine($"{player.Name} current health is {player.Health}");
                    }

                    else if (player.Health <= 0)
                    {
                        Console.WriteLine("You died, Game Over");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        playing = false;
                        break;
                    }


                    try
                    {
                        Random playerRandomAttack = new Random();
                        int playerDamage = playerRandomAttack.Next(10, 20);
                        string playerAttackInput = Console.ReadLine();

                        if (playerAttackInput == "F")
                        {


                            enemy.Health -= playerDamage;

                            if (enemy.Health > 0)
                            {
                                Console.WriteLine($"{enemy.Name} current health is {enemy.Health}");
                            }


                            else if (enemy.Health <= 0)
                            {
                                Console.WriteLine($"{enemy.Name} has died, you win");
                                playing = false;
                                break;
                            }

                        }

                        else
                        {
                            throw new NullReferenceException("You did not attack");
                        }
                    }

                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}