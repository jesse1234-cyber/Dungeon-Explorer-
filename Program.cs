using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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
            //Console.WriteLine("welcome to the dragon dungeon ");
            //Console.WriteLine("state your name hero...");
            Player P1 = new Player(Console.ReadLine(), 100);

            //Console.WriteLine("good name you will be remembered  " + P1.Name);
            //Console.WriteLine("your current health is" +     P1.Health);
            
            Console.WriteLine("you make your way towards the gates of a dragon dungeon...");
            Console.WriteLine("the gates rip open and you venture on in side");
            Console.WriteLine("the gates slam closed and you come to look at your new surroundings");

           
            Room room1descrip = new Room("the room fills with a cold and sharp air, lava flows down the walls and the floor is covered in bones and skulls");
           
            Console.WriteLine(room1descrip.GetDescription());





            Console.WriteLine("You take damage!!!");
            P1.takeDamage(20);

            Console.WriteLine("your health is now" + P1.Health);



            // Room room1 = new Room();
            //room1.GetDescription();














            Console.ReadKey();
        }
    }
}
