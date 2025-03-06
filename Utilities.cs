 using System;
using System.Linq;


namespace Program
{
    // Class containing static functions for validating userinputs within the game
    public class GameInputs
    {
        public static int G() // Simple function for returning integers from user input
        {
            int UserInput;
            do
            {
                try
                {
                    UserInput = Int16.Parse(Console.ReadLine());
                    return UserInput;
                }
                catch { Console.WriteLine("Invalid Input"); }
            } while (true);
        }

        // For menus, the user inputs integers. This function is for ensuring the users input is valid within the bounds
        // There is one overload for if a minimum is not provided, it would be assumed to be 1.
        public static int V(int max) { return V(max, 1); }
        public static int V(int max, int min)
        {
            bool Valid = false;

            do
            {
                int UserInput = G();
                if (UserInput <= max)
                {
                    if (UserInput >= min)
                    {
                        return UserInput;
                    }
                }
                Console.WriteLine("Invalid Input");
            } while (Valid == false);
            return 0;
        }

        // Some times in the game key inputs are used. This function gets key inputs and checks that they are valid, in the array given to it.
        public static ConsoleKeyInfo K(ConsoleKeyInfo[] ValidKeys)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (ValidKeys.Contains(key)) { return key; };
            while (ValidKeys.Contains(key) == false)
            {
                key = Console.ReadKey();
            }
            return key;
        }
    }
}