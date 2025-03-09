using System.Runtime.InteropServices;
using System.Linq;
using System;

namespace Program
{
    // Main game class, main code in here and entry point.
    public class Game
    {
        static char[,] Map = new char[10, 20];

        public static void Main(string[] Args)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 19; j++)
                    Map[i, j] = '?';



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
            Console.Clear();
            Player P1 = new Player();


            Map[P1.getPosX(), P1.getPosY()] = 'U';
            Console.WriteLine("   Current Map:    ");
            Console.WriteLine("[U]: Your Current Location");
            Console.WriteLine("[?]: Not Visited Area");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }

            P1.ActionMenu();



            Console.ReadLine();
        }
    }


}
