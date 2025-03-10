using System;

namespace Program
{
    // Main game class, main code in here and entry point.
    public class Game
    {
        static Player P1;
        public static void Main(string[] Args)
        {
            int x, y;
            x = 5; y = 8;
            Map.Init(x, y);
            P1 = new Player();
            Map.UpdateMap(P1.getPosX(), P1.getPosY(), P1.getPosX(), P1.getPosY());

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
        

        static void gameLoop()
        {
            do
            {
                Console.Clear();
                Map.Show();
                P1.ActionMenu();


            } while (true);
        }
    }


}
