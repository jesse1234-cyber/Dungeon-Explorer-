using System;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public void Level1()
        {
            Console.WriteLine("you make your way towards the gates of a dragon dungeon...");  //story description
            Console.WriteLine("the gates rip open and you venture on in side");
            Console.WriteLine("the gates slam closed and you come to look at your new surroundings");

            Room room1descrip = new Room("the room fills with a cold and sharp air, lava flows down the walls and the floor is covered in bones and skulls");

            Console.WriteLine(room1descrip.GetDescription());  // gives thr room description

            Console.WriteLine("you find a health potion on the floor of the first room. do you want to pick it up? (yes/no)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")     //picks up item if answer is "yes" and they dont if the answer is "no"
            {
                player.PickUpItem("health potion");   
            }
            player.showinventory();

            Console.WriteLine("You take damage!!!");
            player.takeDamage(20);    //shows amount of damage taken

            Console.WriteLine("your health is now" + player.Health); //shows new health
        }

        public Game()
        {
            Console.WriteLine("welcome to the dragon dungeon hero, state your name...");
            string playername = Console.ReadLine();
            player = new Player(playername,100);
            //Console.WriteLine("welcome to the dragon dungeon ");
            //Console.WriteLine("state your name hero...");

            // Console.WriteLine($"welcome,{playername}");

            Console.WriteLine("good name you will be remembered  " + player.Name);
            Console.WriteLine("your current health is" + player.Health);




            while (true) 
            {
               Console.WriteLine("\ngame option: 1)check health 2) continue 3)inventory stats");
               string choice = Console.ReadLine();


                if (choice == "1")
                {
                    player.displayhealth();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("click enter to continue");
                    Level1();
                }
                else if (choice == "3")
                {
                    player.showinventory();
                }
                else
                {
                    Console.WriteLine("the option you chose was invalid try again");
                }
               
            
            }

            



           
            
            








            //Handles the game flow and initializes the player and one simple room.

            // Initialize the game with one room and one player

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here

            }
        }
    }
}