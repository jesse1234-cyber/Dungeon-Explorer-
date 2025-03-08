using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
            Console.WriteLine("Welcome to the Pirate Dungeon Explorer!");                      // Start Game
            
            Console.WriteLine("What would you like your username to be?");                     // Assign username
            String name = Console.ReadLine();
            Console.WriteLine("Your username is:" + name);

            Console.WriteLine("You have entered the island by ship, instantly you notice two large caves shaped like skulls");          // Start of Story or Map
            Console.WriteLine("The left cave has a old wooden sign reading 'Beware of the giant spider'");
            Console.WriteLine("The right cave has a rusted metal sign reading 'Beware of the giant snake'");
            Console.WriteLine("So ... " + name);
            Console.WriteLine("Which cave would you like to enter? left or right");
            string roomchoice = Console.ReadLine();                                                                                    // Prompt user for room choice

            if (roomchoice == "left") 
            {
                Console.WriteLine("You chose the spider dungeon");                                                                                                       // First room choice description
                Console.WriteLine("Within this dungeon there are cobwebs along the floors and ceiling, a few small spiders and a dark passageway heading forwards");

            }

            else if (roomchoice == "right")
            {
                Console.WriteLine("You chose the snake dungeon");                                                                                                        // Second room choice description
                Console.WriteLine("Within this dungeon there is a thin layer of water along the floor and a slimy liquid dripping from the ceilings, hissing sounds in the distance and a tiny passageway heading forwards");

            }

            else
            { 
                Console.WriteLine("Invalid Input: Please enter left or right...");                                 // Exception Handling prompt the user to type a correct input
                 
            }


        }
    }
}
