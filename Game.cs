using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        public static void Start()
        {
            Console.WriteLine("Welcome to the Dungeon!"); //welcome message

            //asking the user for their name
            Console.WriteLine("Name:");
            Program.currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have woken up in the first room of the dungeon.");
            //if the user has not submitted a name they are toild their charecter cannot remember their name
            if (Program.currentPlayer.name == "")
                Console.WriteLine("You can't even remeber your name");
            //if the player did submit a name, it is shown back to them
            else
                Console.WriteLine("You can only remember that your name is " + Program.currentPlayer.name);
            Console.ReadKey();
            //Story elements ouputted
            Console.WriteLine("You feel around in the darkness and find a door. You quietly open it and go through.");
            Console.WriteLine("You see your captor in the next room, facing away from you.");
        }

        public static void Story()
        {
            Console.Clear();
            //story text, guiding the user and explaining the objective of the next part of the game
            Console.WriteLine("With your captor dead on the floor you deside to go through his pockets.");
            Console.WriteLine("There isn't much, but you find a crumpled up peice of paper in his pocket.");
            Console.WriteLine("It looks like... a map! There are 5 rooms till the exit. It's time to start your escape...");
            Console.WriteLine("You go through the next door.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}