using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.WriteLine("Please input your name:");
            //Allows an input from the user to take there name. Stores it as variable named "userName"
            string userName = Console.ReadLine();
            //Instantiates a player with the name user, uses "userName" variable as the Name for the player. 
            Player user = new Player(userName, 15);
            Console.WriteLine("Hello " + user.Name);
            Console.WriteLine("Player Statistics:" + "\n" + "Health: " + user.Health);


            //Create a room with name Kitchen and description of Kitchen
            Room kitchen = new Room("Kitchen.");

            //Runs get description for object Kitchen to prints its description to Console. 
            Console.WriteLine(kitchen.GetDescription());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
