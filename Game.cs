using System;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// coding logic where in ther user can interract with the main game,
    /// instances are created for each of the required classes in the game
    /// </summary>
    internal class Game
    {
        private Player player;
        private Player enemy;

        private Room currentRoom;
        private Test test;
       
        /// <summary>
        /// The main game is initialized so that the class can be used,
        /// </summary>
        public Game()
        {
            /// an instance of the test is initialized so that the class can be used
            test = new Test();
            
        
            ///while the boolean inOptions is true the user can enter a username
            bool inOptions = true;

            while (inOptions = true)
            {
                ///<exception cref="NullReferenceException">
                ///if the user does not enter an input this exception will be thrown,
                ///the message will then be displayed in the terminal
                /// </exception>
                try
                {
                    Console.WriteLine("Please enter a username: ");
                    string playerUsername = Console.ReadLine();
                    ///<param name="name">the name of the player</param>
                    ///<param name="health">The health the player has</param>
                    player = new Player(playerUsername, 100);

                    

                    if (playerUsername.Length == 0)
                    {
                        /// <remarks>
                        /// if the username is eaqual to 0 an error will be detected,
                        /// the TestMethod function will then run, displaying the error
                        /// </remarks>
                        Debug.Assert(playerUsername.Length != 0, test.TestMethod());
                        throw new NullReferenceException("No name entered, please try again");
                    }
                    
                    /// <remarks>
                    /// if the username is longer than 0 the while loop will stop,
                    /// moving on to the next code outside of the loop
                    /// </remarks>
                    if (playerUsername.Length > 0)
                    {
                        break;
                    }

                }

                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            ///<remarks>
            ///the player name is displayed and the room is initialized with a description,
            ///an enemy is created by initializing a new instance of the player class with a name and 50 health
            ///</remarks>
            Console.WriteLine($"Welcome {player.Name}");
            currentRoom = new Room("The room is cold and dark, with goblins crawling everywhere");
            enemy = new Player("goblin", 50); 
        }
            
        /// <summary>
        /// this method runs code logic for when the player has started playing the game
        /// </summary>
        public void Start()
        {
            ///<remarks>
            ///the GetDescription function for the room class will run, 
            ///displaying the description set
            /// </remarks>
            Console.WriteLine("Entering Dungeon...");
            Console.WriteLine(currentRoom.GetDescription());
            Console.WriteLine("You can enter 'M' to view the description at any time");
            

            ///<summary>
            ///while the boolean playing is true the code logic in the loop will run
            /// </summary>
            bool playing = true;
            while (playing)
            {
                
                string item;

                ///<summary>
                ///while the boolean lootingRoom is true the code logic in the loop will run
                /// </summary>
                bool lootingRoom = true;
                while (lootingRoom)
                {
                    

                    try
                    {
                        ///<summary>
                        ///if there is an ArgumentOutOfRange exception in the try code it will
                        ///be detected and the code in the catch will run
                        /// </summary>
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
                            Debug.Assert(userMoveInput.Length != 0, test.TestMethod());

                            ///<exception cref="ArgumentOutOfRangeException">
                            ///if the user input is not A, D or W an argument out of range
                            ///exception will be thrown
                            /// </exception>
                            throw new ArgumentOutOfRangeException("Please enter A, D or W to move");
                        }
                    }

                    catch (ArgumentOutOfRangeException ex)
                    {
                        ///<remarks>
                        ///if the exception is thrown the exception message will be displayed
                        /// </remarks>
                        Console.WriteLine(ex.Message);
                    }
                }

                    
                ///<summary>
                ///a message will be displayed that the enemy is is approaching,
                ///the name of the enemy will be displayed
                /// </summary>

                Console.WriteLine($"a {enemy.Name} is approaching...");

                ///<summary>
                ///the user can enter an input after being prompted to view their inventory
                /// </summary>
                Console.WriteLine("Press 'I' to view inventory, press any other key to ignore");
                string viewInventory = Console.ReadLine();

                try
                {
                    if (viewInventory == "I")
                    {
                        ///<remarks>
                        ///if the user enters 'I' the inventory will be displayed, otherwise an exception
                        ///will be throwm and the exception message will be displayed
                        /// </remarks>
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

                ///<summary>
                ///while the boolean battle is true the code in the while loop will run
                /// </summary>
                
                bool battle = true;
                

                while (battle)
                {
                    ///<remarks>
                    ///the enemyRandomAttack is initialized using the random class,
                    ///this means a random value can be assigned
                    /// </remarks>
                    Random enemyRandomAttack = new Random();
                    ///<remarks>
                    ///the value of enemy attack will be a random integer between 10 and 30
                    /// </remarks>
                    int enemyDamage = enemyRandomAttack.Next(10, 30);
                    Console.WriteLine("The goblin has attacked");
                    ///<remarks>
                    ///the value of the enemy damage will be subtracted from the health of the player
                    /// </remarks>
                    player.Health -= enemyDamage;


                    ///<remarks>
                    ///if the health of the player is above 0 their name and health will be displayed
                    /// </remarks>
                    if (player.Health > 0)
                    {
                        Console.WriteLine($"{player.Name} current health is {player.Health}");
                    }

                    ///<remarks>
                    ///if the players health is 0 or below the user will be prompted to enter any key,
                    ///after doing so the playing and battle loops will stop, returning to the main program
                    /// </remarks>
                    else if (player.Health <= 0)
                    {
                        Console.WriteLine("You died, Game Over");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        playing = false;
                        break;
                    }


                    ///<summary>
                    ///This code carries out the same as the aboove code in the battle loop, however a 
                    ///try catch is used as it requests input from the user to battle the enemy.
                    ///</summary>
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
                            ///<exception cref="NullReferenceException">
                            ///there was incorrect input and so the exception is thrown
                            ///</exception>
                            throw new NullReferenceException("You did not attack");
                        }
                    }

                    catch (NullReferenceException ex)
                    {
                        ///<remarks>
                        ///the exception message is displayed
                        /// </remarks>
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}