using System;

namespace DungeonExplorer
{
    internal class Program
    {
        // start of the program
        static void Main(string[] args)
        {
            // set a static window size
            Console.SetWindowSize(120, 30);
            // start the game in a try-catch, in case there was unexpected error
            try
            {
                Console.WriteLine("What username do you want?");
                Game game = new Game(Console.ReadLine(),10);
                game.Start();
            }
            catch ( Exception e) 
            {
                Console.WriteLine("Fatal error made game crash: "+e);
            }
            finally
            {
                Console.WriteLine("Goodbye!\nPress any key to exit...");
                Console.ReadKey();
            }
            
        }
    }
}
