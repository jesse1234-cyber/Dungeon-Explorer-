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
            Room kitchen = new Room("A cold room. The air is heavy and moist, with a distinct smell of Sewage Water. The walls and floor are both made from old cracked stones, and the floor a deep brown rotting wood of some kind. There is a large metallatic table positioned in the centre of the room, potentially a surgical table of some type. There are spots of dried blood painting the floor that surrounded the table.");
            //Runs get description for object Kitchen to prints its description to Console. 
            Console.WriteLine(kitchen.GetDescription());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
