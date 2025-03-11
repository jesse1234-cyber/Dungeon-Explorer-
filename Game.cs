using System;

namespace Program
{
    


    // Main game class, main game loop present in here and entry point.
    public class Game
    {
        // Player instance
        Player P1;
        // Entry point, sets encoding to support unicode and initializes the player and the map, then starts the titlescreen.
        public Game()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int x, y;
            x = 5; y = 8;
            P1 = new Player();
            P1.GameMap.UpdateMap(P1.getPosX(), P1.getPosY(), P1.getPosX(), P1.getPosY());
            titleScreen();
        }

        // Simple game title screen. will have saving at some point
        public void titleScreen()
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
                case 2: // Will eventually Implement saving, not done yet.
                    Console.WriteLine("Not Implemented");
                    break;
            }
           Console.ReadLine();
        }
        

        void gameLoop()
        {
            do
            {
                Console.Clear(); // Clears console at start of new turn
                P1.GameMap.Show(); // Shows Map
                P1.ShowHealth(); // Shows players health
                P1.ActionMenu(); // Runs the action menu of the player

                // Debug.Assert functions for player and hes inventory.
                P1.PlayerDebug();
                P1.pInv.DebugInv();
            } while (true);
        }
    }
}
