using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Player
    {
        //Player stats
        public string name;
        public int coins = 0;
        public int health = 10;
        public int roomCount = 1;

        //Player inventory
        public int armorValue = 0;
        public int potions = 3;
        public string weapon = "Rusty Sword";
        public int weaponValue = 1;

        //Pick up item function where the item type name is handed into the function
        public static void puckUpItem(string itemType)
        {
            if (itemType == "Potion") //method for picking up a potion
            {
                //asking the user if they want to pick up the potion and taking input
                Console.WriteLine("You spot a health potion in the room!");
                Console.WriteLine("Do you pick it up?");
                Console.WriteLine("-------------------------");
                Console.WriteLine("|   (Y)es      (N)o     |");
                Console.WriteLine("-------------------------");
                string move = Console.ReadLine();
                //if statment (coverting all input to lowercase so that capitalised and lowercase is valid)
                if (move.ToLower() == "y")
                {
                    Console.WriteLine("You pick up the potion.");
                    Program.currentPlayer.potions += 1; //adding a potion to the users inventory
                    Console.WriteLine("You now have " + Program.currentPlayer.potions + " potions."); //message to tell the user they picked to potion up
                }
                else if (move.ToLower() == "n")
                {
                    Console.WriteLine("You leave the potion where it is."); //message telling the user they did NOT pick up the potion
                }
                else
                {
                    Console.WriteLine("You leave the potion where it is."); //if the user does not enter a valid input, there is a message telling the user they did NOT pick up the potion
                }
                Console.ReadKey();
                Console.Clear();
            }
            else
                Console.WriteLine("Something went wrong. You cannot pick up this item."); //if the item type is not recognised the user is told they cannot pick up the item
            
        }
    }
}