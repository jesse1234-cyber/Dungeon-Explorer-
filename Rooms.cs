using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Rooms
    {
        static Random rand = new Random();

        //switch case to randomly return a room type
        public static string getRoomType()
        {
            switch (rand.Next(0, 5))
            {
                case 0:
                    return "Cells";
                case 1:
                    return "Vampire Nest";
                case 2:
                    return "Armoury";
                case 3:
                    return "Witch's Lair";
                case 4:
                    return "Library";
                default:
                    return "Office";
            }
        }

        //switch case to creat a 50% chance of a bool being true
        public static bool halfChance()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return false;
            }

        }

        //switch case to creat a 75% chance of a bool being true
        public static bool threeInFourChance()
        {
            switch (rand.Next(0, 5))
            {
                case 0 & 1 & 2 & 3:
                    return true;
                case 4:
                    return false;
                default:
                    return false;
            }

        }

        //get room descrption function (returns string with room description)
        public static string getRoomDescription(string roomType)
        {
            //switch case returning a description based on the room type
            switch (roomType)
            {
                case "Cells":
                    return "Looking around you see iron bars lining the edges of the room, and deep scratches up the wall.\nOh... these are empty prison cells!";
                case "Vampire Nest":
                    return "Coffins!? Ten coffins are in this room, it's dark and smells of damp.\nYou know what this is, it's a vampire nest!";
                case "Armoury":
                    return "This room is filled with empty armour stands and empty weapon wracks.\nThis was an armoury once!";
                case "Witch's Lair":
                    return "This room reaks! It's filled with dusty jars and books... not books... grimoires!\nThis is a witch's lair!";
                case "Library":
                    return "Shelves and shelves of dusty damages books. You pick one up, but it's in a language you cannot understand.\nThis is a library";
                default:
                    return "A desk stands in the middle of the room, but not much else.\nWas this an office?";
            }
        }


        //room action function (generates room and leads the user to picking up the potions and fighting the monsters, as well as moving onto the next room)
        public static void roomActions()
        {
            //define room type and define if there is a potion and if there is a monster
            string roomType = getRoomType();
            bool isMonster = threeInFourChance();
            bool isPotion = halfChance();

            //display room description
            Console.WriteLine("You enter next the room and look around.");
            Console.WriteLine(getRoomDescription(roomType));
            if (isMonster == true) //if there is a monster add a shadow to the outputted room description
                Console.WriteLine("There is a shadow in the corner of the room.");
            Console.ReadKey();
            Console.Clear();

            ////if there us a potion trigger pickUpItem function (player class)
            if (isPotion == true)
                Player.pickUpItem("Potion");

            //if there us a monster trigger combat function (encounter class)
            if (isMonster == true)
            {
                Console.WriteLine("The shadow in the corner starts to move. You tense.");
                Encounters.BasicEncounter();
            }

            //once player has copleted the room actions:
            if (Program.currentPlayer.roomCount == 5) //if the player has completed all the rooms, an escape message is provided
            {
                Console.WriteLine("Through the next door you can see sunlight!");
            }
            else //if the player has NOT completed all the rooms, a message telling them they are about to enter the next room is displayed
            {
                Console.WriteLine("You have done everything you can in this room, you go through the next door.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}