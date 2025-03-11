using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Encounters
    {
        static Random rand = new Random();
        //ENCOUNTERS
        public static void FirstEncounter()
        {
            Console.WriteLine("This room is lit. You spot a rusty sword and pick it up.");
            Console.WriteLine("Your captor hears you and turns!");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Human Rouge", "Sword", 4);
        }
        public static void BasicEncounter()
        {
            Console.WriteLine("You have been spotted and have no choice but to fight!");
            Combat(true, "", "", 0);
        }


        //COMBAT FUNCTION
        //this function handles the frighting between the moster and the user
        public static void Combat(bool random, string name, string weapon, int health)
        {
            string n = "";
            string w = "";
            int p = 0;
            int h = 0;

            //Define the name, health, and weapon of a random monster
            if (random)
            {
                {
                    n = GetName();
                    h = rand.Next(1, 8);
                    w = GetWeapon();
                }
            }
            //Define the name, health, and weapon of a pre determined monster
            else
            {
                n = name;
                h = health;
                w = weapon;
            }

            //Define the power of a monster, based on the weapon
            switch (w)
            {
                case "Sword":
                    p = 2;
                    break;
                case "Dagger":
                    p = 1;
                    break;
                case "Hammer":
                    p = 2;
                    break;
                case "Rapier":
                    p = 3;
                    break;
                default:
                    p = 2;
                    break;

            }

            //Output to the user what monster they are fighting
            Console.WriteLine("You are now fighting a " + n + ".");
            Console.WriteLine("They wield a " + w + " that has a weapon value of " + p + ".");
            Console.ReadKey();

            //While both the player and the monster are alive, loop the combat cycle
            while (h > 0 && Program.currentPlayer.health > 0)
            {
                //Ask the user for their input (what combat action would they like to take)
                Console.Clear();
                Console.WriteLine("Potions: " + Program.currentPlayer.potions);
                Console.WriteLine("Health: " + Program.currentPlayer.health);
                Console.WriteLine(n + ": " + h);
                Console.WriteLine("-------------------------");
                Console.WriteLine("|  (A)ttack    (D)efend  |");
                Console.WriteLine("|  (H)eal                |");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Make your move! Enter A, D, or H:");
                string move = Console.ReadLine(); //taking the users input

                //IN IF STATMENT: all input is changed into lower case, so both capital and lowercase inputs are valid
                //attack
                if (move.ToLower() == "a")
                {
                    Console.WriteLine("You attack your enemy!");
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue + 1) + rand.Next(1, 4); //randomly generate an amount of damage and add the weapon value to it
                    int damage = p - Program.currentPlayer.armorValue; //subtract the players armour value frpom the mosters power
                    if (damage < 0) //check the damage is not in the negatives, if it is change it to 0
                        damage = 0;
                    Console.WriteLine("The " + n + " loses " + attack + " health, but serves you " + damage + " damage."); //message to tell the user how much damage they have delt and taken
                    Program.currentPlayer.health -= damage; //changing the users health
                    h -= attack; //changing the monsters health
                }
                
                //defend
                else if (move.ToLower() == "d")
                {
                    Console.WriteLine("You defend yourself against your enemy!");
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue + 1); //randomly generate an amount of damage between 0 and the users weapon value
                    int damage = p / 4 - Program.currentPlayer.armorValue; //
                    if (damage < 0) //check the damage is not in the negatives
                        damage = 0;
                    Console.WriteLine("You only lose " + damage + " health, and manage to serve " + damage + " damage to the " + n + "."); //message to tell the user how much damage they have delt and taken
                    Program.currentPlayer.health -= damage; //changing the users health
                    h -= attack; //changing the monsters health
                }

                //heal
                else if (move.ToLower() == "h")
                {
                    if (Program.currentPlayer.potions == 0)
                    {
                        int damage = p - Program.currentPlayer.armorValue; //subtract the players armour value frpom the mosters power
                        if (damage < 0) //check the damage is not in the negatives, if it is change it to 0
                            damage = 0;
                        Console.WriteLine("You reach for your potions, but find you do not have any left! You are unable to heal yourself."); //message telling the user they have no potions left
                        Program.currentPlayer.health -= damage; //changing the users health
                        Console.WriteLine("While you were distracted, the " + n + "attacks! You lose " + damage + "health."); //message telling the user how much damge they have taken
                    }
                    else
                    {
                        Console.WriteLine("You grab a potion from your bag, drinking it as fast as you can.");
                        int potionValue = 5;
                        if (potionValue + Program.currentPlayer.health > 10) //if statment insuring the users healh does not exceed 10
                            potionValue = potionValue - (potionValue + Program.currentPlayer.health - 10);

                        Program.currentPlayer.health += potionValue; //changing the users health
                        Program.currentPlayer.potions -= 1; // changing the number of potions in the users inventory
                        Console.WriteLine("You gain " + potionValue + " health."); //message to the user telling them how much health they gain


                    }
                }
                
                //ask again
                else
                {
                    Console.WriteLine("That is not a valid move. The " + n + " looks at you confused."); //message telling the user their input was invalid
                    Console.WriteLine("Please try again."); //asking the user to resubmit, looping from the start of the while loop
                }
                Console.ReadKey();

            }

            //once the loop has ended
            Console.Clear();
            if (Program.currentPlayer.health <= 0)
                Console.WriteLine(n + " deals a fatel blow and everything goes dark."); //message for if the user dies
            else
            {
                Console.WriteLine("You have killed the " + n + "."); //message for if the user wins
                Console.ReadKey();
            }
        }
        public static string GetName()
        {
            //Randomly generated switch case to deside what monster
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Vampire";
                case 1:
                    return "Troll";
                case 2:
                    return "Witch";
                case 3:
                    return "Cyclopes";
                default:
                    return "Human Rouge";

            }
        }

        public static string GetWeapon()
        {
            //Randomly generated switch case to deside what weapon
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Sword";
                case 1:
                    return "Dagger";
                case 2:
                    return "Hammer";
                case 3:
                    return "Rapier";
                default:
                    return "Spear";

            }
        }

    }
}
