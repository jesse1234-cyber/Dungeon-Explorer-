using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// main code logic for running of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// the main function is the code which will run, causing the program to run
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to dungeon explorer");
                ///<remarks>
                ///a new instance of the game class is initialized causing the code in the class to run,
                ///the start method in the game class is called so that the code in the start method runs
                /// </remarks>
                Game game = new Game();
                game.Start();
            }

            catch (Exception)
            {
                ///<remarks>
                ///if there is an error in the try, this message will be displayed
                /// </remarks>
                Console.WriteLine("Error has Occured");
            }

            finally
            {
                ///<remarks>
                ///this code will run regardless of whether there is an exception or not
                /// </remarks>
                Console.WriteLine("Waiting for your Implementation");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
