using System.Runtime.InteropServices;
using System.Linq;
using System;
using System.Security.Cryptography;

namespace Program
{
    // Main game class, main code in here and entry point.
    public class Game
    {
        static Player P1;
        public static void Main(string[] Args)
        {
            P1 = new Player();

            Map.Init(P1.getPosX(), P1.getPosY());
            titleScreen();
        }



        public static void titleScreen()
        {
            Console.WriteLine("The Legend Of Zelda: Adventure In Text");
            Console.WriteLine("[1] New Game");
            Console.WriteLine("[2] Load");
            switch (GameInputs.V(2))
            {
                case 1:
                    Console.WriteLine("Starting Game");
                    gameLoop();
                    break;  
                case 2:
                    Console.WriteLine("Sausage roll");
                    break;
            }

            Console.ReadLine();
        }
        static void newGame()
        {

        }

        static void gameLoop()
        {
            do
            {
                Console.Clear();


                Console.WriteLine("   Current Map:    ");
                Console.WriteLine("[U]: Your Current Location");
                Console.WriteLine("[?]: Not Visited Area");
                Map.Show();

                P1.ActionMenu();


            } while (true);
        }
    }


}
